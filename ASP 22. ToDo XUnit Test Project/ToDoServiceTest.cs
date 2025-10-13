using ASP_23._Unit_Test.Data;
using ASP_23._Unit_Test.DTOs;
using ASP_23._Unit_Test.DTOs.Pagination;
using ASP_23._Unit_Test.Models;
using ASP_23._Unit_Test.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
namespace ASP_22._ToDo_XUnit_Test_Project;

public class ToDoServiceTest
{
    //AAA
    // Arrange - teste hazirliq
    // Act - funkisonali ishe salinmasi
    // Assert - problem olub olmadigini bildirir
    public static IEnumerable<object[]> AddData()
    {
        yield return new object[] { 1, 4, 5 };
        yield return new object[] { 13, 7, 20 };
        yield return new object[] { 2, -4, -2 };
        yield return new object[] { 69, 96, 165 };
        yield return new object[] { 10, 40, 50 };
        yield return new object[] { 10, 41, 51 };
    }


    [Theory]
    //[InlineData(1, 4, 5)]
    //[InlineData(13, 7, 20)]
    //[InlineData(2, -4, -2)]
    //[InlineData(10, 41, 51)]
    [MemberData(nameof(AddData))]
    public void Add_ReturnResult(int left, int right, int exceptResult)
    {
        // Arrange
        var calc = new Calculator();
        // Act
        var actualResult = calc.Add(left, right);
        // Assert
        Assert.Equal(actualResult, exceptResult);
    }

    [Fact]
    public async Task GetToDoItem_ReturnToDoItemWhichBelongUser()
    {
        // Arrange
        var dbContext = new ToDoContext(
            new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase("Test").Options);
        var user = dbContext.Users.Add(new AppUser
        {
            UserName = "Nadir",
            Email = "Zamanov@itstep.org"
        }).Entity;

        var createdToDoItem = dbContext.ToDoItems.Add(
            new ToDoItem
            {
                Text = "Salam",
                UserId = user.Id
            }).Entity;

        dbContext.SaveChanges();
        var service = new ToDoService(dbContext);

        // Act
        var retrivedToDoItem
            = await service
            .GetToDoItemAsync(user.Id, createdToDoItem.Id);

        // Assert
        Assert.NotNull(retrivedToDoItem);
    }

    [Fact]
    public async Task GetToDoItem_ReturnToDoItemWhichNotBelongUser()
    {
        // Arrange
        var dbContext = new ToDoContext(
            new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase("Test").Options);
        var user = dbContext.Users.Add(new AppUser
        {
            UserName = "Nadir",
            Email = "Zamanov@itstep.org"
        }).Entity;

        var otherUser = dbContext.Users.Add(new AppUser
        {
            UserName = "Tunay",
            Email = "Tunay@gmail.com"
        }).Entity;

        var createdToDoItem = dbContext.ToDoItems.Add(
            new ToDoItem
            {
                Text = "Salam",
                UserId = user.Id
            }).Entity;

        dbContext.SaveChanges();
        var service = new ToDoService(dbContext);

        // Act
        var retrivedToDoItem
            = await service
            .GetToDoItemAsync(otherUser.Id, createdToDoItem.Id);

        // Assert
        Assert.Null(retrivedToDoItem);
    }

    [Fact]
    public async Task GetToDoItems_ReturnPaginatedToDoItemWhichBelongUser()
    {
        // Arrange
        var dbContext = new ToDoContext(
            new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase("Test").Options);
        var user = dbContext.Users.Add(new AppUser
        {
            UserName = "Nadir",
            Email = "Zamanov@itstep.org"
        }).Entity;



        dbContext.ToDoItems.AddRange(Enumerable
            .Range(1, 10)
            .Select(i => new ToDoItem
            {
                Text = $"Test {i}",
                UserId = user.Id
            }).ToList());

        dbContext.SaveChanges();
        var service = new ToDoService(dbContext);

        // Act
        var retrivedToDoItems
            = await service
            .GetToDoItemsAsync(user.Id, 1, 3, null, null);

        // Assert
        #region simple Assert
        //Assert.Equal(3, retrivedsToDoItem.Items.Count());
        //Assert.Equal(1, retrivedsToDoItem.Meta.Page);
        //Assert.Equal(3, retrivedsToDoItem.Meta.PageSize);
        //Assert.Equal(4, retrivedsToDoItem.Meta.TotalPages);

        //Assert.Collection(retrivedToDoItems.Items,
        //    item=> Assert.Equal("Test 1", item.Text),
        //    item=> Assert.Equal("Test 2", item.Text),
        //    item=> Assert.Equal("Test 3", item.Text)
        //    );
        #endregion

        #region Fluent Assertion
        retrivedToDoItems.Should().NotBeNull();
        retrivedToDoItems.Items.Count().Should().Be(3);
        //retrivedToDoItems.Meta.PageSize.Should().Be(3);
        //retrivedToDoItems.Meta.Page.Should().Be(1);
        //retrivedToDoItems.Meta.TotalPages.Should().Be(4);
        retrivedToDoItems.Meta.Should().BeEquivalentTo(new PaginationMeta(1, 3, 10));

        //retrivedToDoItems.Items.Should().ContainSingle(item => item.Text == "Test 1");
        //retrivedToDoItems.Items.Should().ContainSingle(item => item.Text == "Test 2");
        //retrivedToDoItems.Items.Should().ContainSingle(item => item.Text == "Test 3");

        retrivedToDoItems.Items.Should()
             .ContainSingle(item => item.Text == "Test 1")
            .And.ContainSingle(item => item.Text == "Test 2")
            .And.ContainSingle(item => item.Text == "Test 3");
        #endregion
    }

    [Fact]
    public async Task CreateToDoItem_ThrowsException_UserNotFound()
    {
        //Arrange
        var dbContext = new ToDoContext(
            new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase("Test").Options);
        var createdToDoItem = new CreateToDoItemRequest()
        {
            Text = "Salam"
        };

        var userId = "1";
        var emailSender = new FakeEmailSender();
        var service = new ToDoService(dbContext, emailSender);

        // Act
        //try
        //{
        //    var retrivedToDoItem =
        //        await service.CreateToDoAsync(userId, createdToDoItem);
        //}
        //catch (Exception ex)
        //{
        //    Assert.True(ex is KeyNotFoundException);
        //}

        //Record.ExceptionAsync(async () =>
        //{
        //    var retrivedToDoItem = await service.CreateToDoAsync(userId, createdToDoItem);

        //}).Result.Should().BeOfType<KeyNotFoundException>();


        await service.Awaiting(s => s.CreateToDoAsync(userId, createdToDoItem))
            .Should()
            .ThrowAsync<KeyNotFoundException>();
    }

    [Fact]
    public async Task CreateToDoItem_And_SendEmailNotificaton()
    {
        // Arrange
        var dbContext = new ToDoContext(
           new DbContextOptionsBuilder<ToDoContext>()
           .UseInMemoryDatabase("Test").Options);

        var user = dbContext.Users.Add(new AppUser
        {
            UserName = "Test",
            Email = "test@gmail.com"
        }).Entity;


        var createdToDoItem = new CreateToDoItemRequest()
        {
            Text = "Salam"
        };

        var emailSender = new Mock<IEmailSender>(MockBehavior.Strict);
        emailSender.Setup(e => e.SendEmail(user.Email,
            It.Is<string>(s => s.Contains(createdToDoItem.Text)),
            It.IsAny<string>()
            ))
            .Returns(Task.CompletedTask);

        await dbContext.SaveChangesAsync();
        var service = new ToDoService(dbContext);

        await service.Awaiting(s => s.CreateToDoAsync("user.Id", createdToDoItem))
                        .Should()
                        .ThrowAsync<KeyNotFoundException>();



    }
}
