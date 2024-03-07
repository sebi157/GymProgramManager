using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using GPM.Controllers;
using GPM.Services.Programs;
using GPM.Models;
using GPM.Contracts.Program;

public class ProgramsControllerTests
{
    private readonly Mock<IProgramService> _mockService;
    private readonly ProgramsController _controller;

    public ProgramsControllerTests()
    {
        _mockService = new Mock<IProgramService>();
        _controller = new ProgramsController(_mockService.Object);
    }

    [Fact]
    public void CreateProgram_ReturnsCreatedAtAction_WhenSuccessful()
    {
        // Arrange
        var programRequest = new CreateProgramRequest
        (
            "New Program",
            "New Description",
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(1),
            new List<string> { "Exercise 1" }
        );

        // Assuming CreateTestProgram() is a helper method that uses GProgram.Create()
        // and wraps the result in an ErrorOr<Created> indicating success.
        var createdProgramResult = GProgram.Create(
            programRequest.Name,
            programRequest.Description,
            programRequest.StartDateTime,
            programRequest.EndDateTime,
            programRequest.Exercises
        );

        // Ensure the creation was successful before proceeding.
        Assert.True(createdProgramResult.IsSuccess);

        // The service layer should return an ErrorOr<Created> object with a Created success marker.
        _mockService.Setup(s => s.CreateProgram(It.IsAny<GProgram>()))
        .Returns(ErrorOr.Success(new Created()));

        // Act
        var result = _controller.CreateProgram(programRequest);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        _mockService.Verify(s => s.CreateProgram(It.IsAny<GProgram>()), Times.Once);

        // Assuming your Created object contains the ID of the created program, and
        // the ProgramResponse object within the CreatedAtActionResult is correctly instantiated.
        // This part may need adjustment based on how your Created and ProgramResponse objects are structured.
        Assert.Equal(createdProgramResult.Value.Id, ((ProgramResponse)actionResult.Value).Id);
    }
}
