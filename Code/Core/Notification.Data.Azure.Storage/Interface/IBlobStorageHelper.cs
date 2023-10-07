﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace Notification.Data.Azure.Storage.Interface
{
    public interface IBlobStorageHelper
    {
        /// <summary>
        /// Gets the Blob Uri
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="blobName"></param>
        /// <returns></returns>
        string GetBlobUri(string containerName, string blobName);

        /// <summary>
        /// Gets the listBlobsHierarchicalListing
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="prefix"></param>
        /// <param name="segmentSize"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        Task<List<BlobItem>> ListBlobsHierarchicalListing(string containerName, string? prefix, int? segmentSize, BlobContainerClient? container = null);

        /// <summary>
        /// Check if container name exist at storage account
        /// </summary>
        /// <param name="containerName">Storage container name</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>bool</returns>
        Task<bool> DoesExist(string containerName, string blobName);

        /// <summary>
        /// Save the byte arrray to blob
        /// </summary>
        /// <param name="data">Byte array data</param>
        /// <param name="containerName">Storage container name</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>Task</returns>
        Task UploadByteArray(byte[] data, string containerName, string blobName);

        /// <summary>
        /// Save the stream data to blob
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="containerName">Storage container name</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>Task</returns>
        Task<string> UploadStreamData(Stream stream, string containerName, string blobName);

        /// <summary>
        /// Saves text to blob
        /// </summary>
        /// <param name="data">Text data </param>
        /// <param name="containerName">Storage container name</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>Task</returns>
        Task UploadText(string data, string containerName, string blobName);

        /// <summary>
        /// Upload file to blob
        /// </summary>
        /// <param name="files"></param>
        /// <param name="blobName"></param>
        /// <param name="containerName"></param>
        /// <param name="filename"></param>
        Task UploadFileToBlob(List<IFormFile> files, string blobName, string containerName, string filename);

        /// <summary>
        /// Upload file to blob async
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="fileData"></param>
        /// <param name="fileMimeType"></param>
        /// <param name="blobFolderName"></param>
        /// <param name="containerName"></param>
        Task UploadFileToBlobAsync(string strFileName, string fileData, string fileMimeType, string blobFolderName, string containerName);

        /// <summary>
        /// Upload image file to blob async
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="file"></param>
        /// <param name="fileMimeType"></param>
        /// <param name="containerName"></param>
        Task UploadImageFileToBlobAsync(string strFileName, IFormFile file, string fileMimeType, string containerName);

        /// <summary>
        /// Download text data from blob
        /// </summary>
        /// <param name="containerName">Storage container name</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>string</returns>
        Task<string> DownloadText(string containerName, string blobName);

        /// <summary>
        /// Download blob from storage
        /// </summary>
        /// <param name="containerName">Storage container name</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>Byte array data</returns>
        Task<byte[]> DownloadByteArray(string containerName, string blobName);

        /// <summary>
        /// Download stream data from blob
        /// </summary>
        /// <param name="containerName">Storage container name</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>Memory Stream</returns>
        Task<MemoryStream> DownloadStreamData(string containerName, string blobName);

        /// <summary>
        /// Deletes data from blob
        /// </summary>
        /// <param name="containerName">Storage container name</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>Task</returns>
        Task DeleteBlob(string containerName, string blobName);
    }
}