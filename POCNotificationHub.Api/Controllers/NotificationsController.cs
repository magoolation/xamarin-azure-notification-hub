﻿using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POCNotificationHub.Api.Models;
using POCNotificationHub.Api.Services;

namespace POCNotificationHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPut]
    [Route("installations")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> UpdateInstallation(
        [Required] DeviceInstallation deviceInstallation)
    {
        var success = await _notificationService
            .CreateOrUpdateInstallationAsync(deviceInstallation, HttpContext.RequestAborted);

        if (!success)
            return new UnprocessableEntityResult();

        return new OkResult();
    }

    [HttpDelete()]
    [Route("installations/{installationId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<ActionResult> DeleteInstallation(
        [Required][FromRoute] string installationId)
    {
        var success = await _notificationService
            .DeleteInstallationByIdAsync(installationId, CancellationToken.None);

        if (!success)
            return new UnprocessableEntityResult();

        return new OkResult();
    }

    [HttpPost]
    [Route("requests")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> RequestPush(
        [Required] NotificationRequest notificationRequest)
    {
        if ((notificationRequest.Silent &&
            string.IsNullOrWhiteSpace(notificationRequest?.Action)) ||
            (!notificationRequest.Silent &&
            string.IsNullOrWhiteSpace(notificationRequest?.Text)))
            return new BadRequestResult();

        var success = await _notificationService
            .RequestNotificationAsync(notificationRequest, HttpContext.RequestAborted);

        if (!success)
            return new UnprocessableEntityResult();

        return new OkResult();
    }
}