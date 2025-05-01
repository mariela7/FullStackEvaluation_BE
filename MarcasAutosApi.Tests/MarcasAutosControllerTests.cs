using Xunit;
using MarcasAutosApi.Controllers;
using MarcasAutosApi.Data;
using MarcasAutosApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MarcasAutosApi.Tests
{
    public class MarcasAutosControllerTests
    {
        private ApplicationDbContext GetDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            var context = new ApplicationDbContext(options);

            if (!context.MarcasAutos.Any())
            {
                context.MarcasAutos.AddRange(
                    new MarcaAuto { Id = 1, Nombre = "Toyota" },
                    new MarcaAuto { Id = 2, Nombre = "Ford" }
                );
                context.SaveChanges();
            }

            return context;
        }

        [Fact]
        public async Task GetMarcas_ReturnsAllMarcas()
        {
            // Arrange
            var context = GetDbContext("GetMarcasTestDb");
            var controller = new MarcasAutosController(context);

            // Act
            var result = await controller.GetMarcas();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var marcas = Assert.IsAssignableFrom<List<MarcaAuto>>(okResult.Value);

            Assert.Equal(2, marcas.Count);
            Assert.Contains(marcas, m => m.Nombre == "Toyota");
        }

        [Fact]
        public async Task GetMarca_ReturnsCorrectMarca()
        {
            var context = GetDbContext("GetMarcaTestDb");
            var controller = new MarcasAutosController(context);

            var result = await controller.GetMarca(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var marca = Assert.IsType<MarcaAuto>(okResult.Value);
            Assert.Equal("Toyota", marca.Nombre);
        }

        [Fact]
        public async Task GetMarca_ReturnsNotFound_WhenNotExists()
        {
            var context = GetDbContext("GetMarcaNotFoundDb");
            var controller = new MarcasAutosController(context);

            var result = await controller.GetMarca(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateMarca_AddsNewMarca()
        {
            var context = GetDbContext("CreateMarcaTestDb");
            var controller = new MarcasAutosController(context);

            var nuevaMarca = new MarcaAuto { Nombre = "Honda" };
            var result = await controller.CreateMarca(nuevaMarca);

            var createdAt = Assert.IsType<CreatedAtActionResult>(result.Result);
            var marca = Assert.IsType<MarcaAuto>(createdAt.Value);
            Assert.Equal("Honda", marca.Nombre);

            Assert.Equal(3, context.MarcasAutos.Count());
        }


        [Fact]
        public async Task DeleteMarca_RemovesMarca_WhenExists()
        {
            var context = GetDbContext("DeleteMarcaTestDb");
            var controller = new MarcasAutosController(context);

            var result = await controller.DeleteMarca(1);

            Assert.IsType<NoContentResult>(result);
            Assert.Null(await context.MarcasAutos.FindAsync(1));
        }

        [Fact]
        public async Task DeleteMarca_ReturnsNotFound_WhenMissing()
        {
            var context = GetDbContext("DeleteMarcaNotFoundDb");
            var controller = new MarcasAutosController(context);

            var result = await controller.DeleteMarca(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateMarca_ReturnsBadRequest_WhenModelInvalid()
        {
            var context = GetDbContext("CreateMarcaInvalidTestDb");
            var controller = new MarcasAutosController(context);

            controller.ModelState.AddModelError("Nombre", "Requerido");

            var result = await controller.CreateMarca(new MarcaAuto());

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

    }
}
