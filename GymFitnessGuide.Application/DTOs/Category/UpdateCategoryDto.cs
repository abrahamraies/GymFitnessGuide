namespace GymFitnessGuide.Application.DTOs.Category
{
    public class UpdateCategoryDto
    {
        // Por ahora categorias solo tienen un nombre, pero si mas adelante cambia es mejor mantener limpios los DTOs. PRINCIPIO DE RESPONSABILIDAD UNICA
        public required string Name { get; set; }
    }
}
