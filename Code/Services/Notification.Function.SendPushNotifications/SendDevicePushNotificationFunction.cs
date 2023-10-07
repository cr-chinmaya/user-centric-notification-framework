// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Notification.Function.SendPushNotifications;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using BL.Common;
using BL.Common.Extension;
using Contract;
using Interface;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model.Model;
using Newtonsoft.Json;
using Notification.BL.Common.Interface;
using Notification.Data.Azure.Storage.Interface;

public class SendDevicePushNotificationFunction
{
    private readonly IConfiguration _config;
    private readonly IPushNotificationHelper _pushNotificationHelper;
    private readonly IUtilityHelper _utilityHelper;
    private readonly IBlobStorageHelper _blobStorageHelper;

    /// <summary>
    /// SendDevicePushNotificationFunction Initialization
    /// </summary>
    /// <param name="config">Configuration object</param>
    /// <param name="pushNotificationHelper">Push Notification Helper</param>
    /// <param name="utilityHelper">Utility Helper</param>
    /// <param name="blobStorageHelper">BlobStorage Helper</param>
    public SendDevicePushNotificationFunction(IConfiguration config, IPushNotificationHelper pushNotificationHelper, IUtilityHelper utilityHelper, IBlobStorageHelper blobStorageHelper)
    {
        _config = config;
        _pushNotificationHelper = pushNotificationHelper;
        _utilityHelper = utilityHelper;
        _blobStorageHelper = blobStorageHelper;
    }

    [FunctionName("SendDevicePushNotification")]
    public async Task Run([ServiceBusTrigger("%DevicePushQueueName%", Connection = "ServiceBusNamespace")] ServiceBusMessage message, ILogger logger)
    {
        LogData logData = new LogData()
        {
            EventDetails = new Dictionary<string, object>()
            {
                { Constant.BusinessProcessName, "Notification - Send Device Push Notification" },
                { Constant.ActionUri, "SendDevicePushNotification" },
                { Constant.ComponentType, ComponentType.BackgroundProcess }
            }
        };

        try
        {
            var tenantId = message.ApplicationProperties["tenantId"].ToString();
            var blobName = $"{tenantId}/{message.MessageId}";

            byte[] payload;
            bool isDataInBlob = (bool)message.ApplicationProperties["IsDataInBlob"];
            if (isDataInBlob)
            {
                payload = await _blobStorageHelper.DownloadByteArray(Constant.AttachmentsBlobContainer, blobName);
            }
            else
            {
                payload = message.Body.ToArray();
            }

            // Decompress message before deserializing
            string decompressedPayload = await _utilityHelper.DecompressMessage(payload);

            var notificationPayload = JsonConvert.DeserializeObject<NotificationItem>(decompressedPayload);

            logData.EventDetails.Modify(Constant.ApplicationName, $"{notificationPayload.ApplicationName}");
            logData.EventDetails.Modify(Constant.TenantIdentifier, $"{notificationPayload.TenantIdentifier}");
            logData.EventDetails.Modify(Constant.Xcv, $"{notificationPayload.Telemetry?.Xcv}");
            logData.EventDetails.Modify(Constant.MessageId, $"{notificationPayload.Telemetry?.MessageId}");
            logData.EventDetails.Modify(Constant.Id, $"{notificationPayload.Id}");

            await _pushNotificationHelper.ProcessDevicePushNotificationRequestsAsync(notificationPayload);

            logData.EventDetails.Modify(Constant.AppAction, "Notification - Send Device Push Notification - Complete");
            using (logger.BeginScope(logData.EventDetails))
            {
                logger.LogInformation(new EventId((int)EventIds.SendDevicePushNotificationCompleted),
                    "Notification - Send Device Push Notification - Complete");
            }
        }
        catch (Exception ex)
        {
            logData.EventDetails.Modify(Constant.AppAction, "Notification - Send Device Push Notification - Failed - Exception");
            using (logger.BeginScope(logData.EventDetails))
            {
                logger.LogError(new EventId((int)EventIds.SendDevicePushNotificationError),
                    ex,
                    "Notification - Send Device Push Notification - Failed - Exception");
            }
            throw;
        }
    }
}