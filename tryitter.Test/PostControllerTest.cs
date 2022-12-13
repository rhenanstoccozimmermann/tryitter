namespace Tryitter.test
{
    public class PostControllerTest
    {
    
        [Fact]
        public void Test_AddPost_Fail()
        {        
            //Arrange
            var postFail = new Post 
            {
                AccountId = 1
            };
            Post? post = null;
            // declara um mock do service
            var mockService = new Mock<IPostService>();
            mockService.Setup(x=>x.AddPost(postFail)).Returns(post);

            //Act
            // criar uma instancia do controller
            // usa o objeto com props faltando como parametro
            var PostController = new PostController(mockService.Object);
            var response  = PostController.AddPost(postFail) as NotFoundObjectResult;

            //Assert


            // chamar a função do controller
           response.Should().BeOfType(typeof(NotFoundObjectResult));
           post?.PostId.Should().Be(0);
           post?.Content.Length.Should().NotBe(300);
           response?.Value.Should().Be("Conta não encontrada");
      
        }

        
        [Fact]
        public void Test_AddPost_Success()
        {
            // seguir o cenario com os mocks validos;
            var post = new Post {
                AccountId = 2,
                Content = "this is a test of a post"
            };

            var postReturned = new Post {
                PostId = 1,
                AccountId = 2,
                Content = "this is a test of a post"
            };
            
            // //Arrange
            // // declara um mock do service
            var mockService = new Mock<IPostService>();
            mockService.Setup(x=>x.AddPost(post)).Returns(postReturned);

            // //Act
            // // criar uma instancia do controller
            var PostController = new PostController(mockService.Object);
            var response  = PostController.AddPost(post) as OkObjectResult;

            // //Assert
            // chamar a função do controller
            response.Should().BeOfType(typeof(OkObjectResult));
            response?.Value.Should().BeEquivalentTo(postReturned);            
        }
    }
}