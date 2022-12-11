namespace Tryitter.test
{
    public class PostControllerTest
    {
    
        [Fact]
        public void Test_AddPost_Fail()
        {
          
            
            //Arrange
            // Declara 2 objetos do tipo Post (um faltando propriedades e outro nulo)
            // declara um mock do service
            var mockService = new Mock<IPostService>();
            // usar objeto com props faltando no primeiro parametro, e o nulo no segundo(Returns...) 
            //mockService.Setup(x=>x.AddPost()).Returns();

            //Act
            // criar uma instancia do controller
            // usa o objeto com props faltando como parametro
            //var PostController = new PostController(mockService.Object);
            //var response  = PostController.AddPost(PostFail) as BadRequestObjectResult;

            //Assert
            // se account é valido
            // se o Content é menor ou igual a 300 caracteres

            // chamar a função do controller
           // response.Should().BeOfType(typeof(BadRequestObjectResult));
          //  response?.Value.Should().Be("Dados inválidos");
      
        }

        
        [Fact]
        public void Test_AddPost_Success()
        {
            // seguir o cenario com os mocks validos;
            
            // //Arrange
            // // declara um mock do service
            // var mockService = new Mock<IPostService>();
            // mockService.Setup(x=>x.AddPost(Post)).Returns(PostReturned);

            // //Act
            // // criar uma instancia do controller
            // var PostController = new PostController(mockService.Object);
            // var response  = PostController.AddPost(Post) as OkObjectResult;

            // //Assert
            // // chamar a função do controller
            // response.Should().BeOfType(typeof(OkObjectResult));
            // response?.Value.Should().BeEquivalentTo(PostReturned);
        }
    }
}