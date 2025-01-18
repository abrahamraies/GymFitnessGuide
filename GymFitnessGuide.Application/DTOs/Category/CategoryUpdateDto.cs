namespace GymFitnessGuide.Application.DTOs.Category
{
    public class CategoryUpdateDto
    {
        // Por ahora categorias solo tienen un nombre, pero si mas adelante cambia es mejor mantener limpios los DTOs. PRINCIPIO DE RESPONSABILIDAD UNICA
        public string? Name { get; set; }
    }
}
