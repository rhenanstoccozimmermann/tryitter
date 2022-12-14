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
                PostId = 1
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

        [Fact]
        public void Test_GetPostsByAccountIdById_Fail() {  
            List<Post>? Posts = null;
            var mockId = 99999;
            
            //Arrange
            // declara um mock do service
            var mockService = new Mock<IPostService>();
            mockService.Setup(x=>x.GetPostsByAccountId(mockId)).Returns(Posts);

            //Act
            // criar uma instancia do controller
            var PostController = new PostController(mockService.Object);
            var response  = PostController.GetPostsByAccountId(mockId) as NotFoundObjectResult;

            //Assert
            // chamar a função do controller
            response.Should().BeOfType(typeof(NotFoundObjectResult));
            response?.Value.Should().Be("Nenhum post encontrado");
        }

        [Fact]
        public void Test_GetPostsByAccountIdById_Success() {   
            List<Post> Posts = new()
            {
                new Post()
                {
                    PostId = 1,
                    AccountId = 1,
                    Image = "uhdaiusdiuasdjiadd",
                    Content = "Meu primeiro post",
                }
            };
            var mockId = 1;
            
            //Arrange
            // declara um mock do service
            var mockService = new Mock<IPostService>();
            mockService.Setup(x=>x.GetPostsByAccountId(mockId)).Returns(Posts);

            //Act
            // criar uma instancia do controller
            var PostController = new PostController(mockService.Object);
            var response  = PostController.GetPostsByAccountId(mockId) as OkObjectResult;

            //Assert
            // chamar a função do controller
            response.Should().BeOfType(typeof(OkObjectResult));
            response?.Value.Should().BeEquivalentTo(Posts);
        }

        [Fact]
        public void Test_GetPostById_Fail() {         
            Post? Post = null;
            var mockId = 99999;
            
            //Arrange
            // declara um mock do service
            var mockService = new Mock<IPostService>();
            mockService.Setup(x=>x.GetPostById(mockId)).Returns(Post);

            //Act
            // criar uma instancia do controller
            var PostController = new PostController(mockService.Object);
            var response  = PostController.GetPostById(mockId) as NotFoundObjectResult;

            //Assert
            // chamar a função do controller
            response.Should().BeOfType(typeof(NotFoundObjectResult));
            response?.Value.Should().Be("Post não encontrado");
        }

        [Fact]
        public void Test_GetPostById_Success() {         
            Post Post =  new Post()
            {
                PostId = 1,
                AccountId = 1,
                Image = "uhdaiusdiuasdjiadd",
                Content = "Meu primeiro post",
            };
            var mockId = 1;
            
            //Arrange
            // declara um mock do service
            var mockService = new Mock<IPostService>();
            mockService.Setup(x=>x.GetPostById(mockId)).Returns(Post);

            //Act
            // criar uma instancia do controller
            var PostController = new PostController(mockService.Object);
            var response  = PostController.GetPostById(mockId) as OkObjectResult;

            //Assert
            // chamar a função do controller
            response.Should().BeOfType(typeof(OkObjectResult));
            response?.Value.Should().BeEquivalentTo(Post);
        }
    }
}