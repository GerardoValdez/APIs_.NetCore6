using ApiDbFirst.Comandos.Usuarios;
using ApiDbFirst.Models;
using ApiDbFirst.Result.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDbFirst.Controllers;

[ApiController]
public class UsuarioController: ControllerBase
{
    private readonly DbFirstContext _context; 
    
    public UsuarioController(DbFirstContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("api/usuario/login")]
    public async Task<ActionResult<ResultadoLogin>> Login([FromBody] ComandoLogin comando)
    {
        try
        {
            var result = new ResultadoLogin();
            
            var usuario = await _context.Usuarios.Where(u =>
                u.Activo && u.Nombre.Equals(comando.NombreUsuario) && u.Password.Equals(comando.Password)).Include(c =>c.IdRolNavigation).FirstOrDefaultAsync();

            if (usuario !=null)
            {
                result.NombreUsuario = usuario.Nombre;
                result.NombreRol = usuario.IdRolNavigation.Rol; //me trae el nombre del rol
                result.StatusCode = "200";
                
                return Ok(result);
            }
            
            result.SetError("Usuario no encontrado en la base de datos.");
            result.StatusCode = "500";
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest("Error al obtener el usuario");
        }
    }
    
    
    [HttpPost]
    [Route("api/usuario/create")]
    public async Task<ActionResult<ResultadoLogin>> CreateUsuario([FromBody] ComandoLogin comando)
    {
        try
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nombre = comando.NombreUsuario,
                Password = comando.Password,
                Activo = true,
                FechaAlta = new DateOnly(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day),
                IdRol = new Guid("aed46536-2873-4154-881f-85b01f9bdc3d")
            };

            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return Ok(true);
            
            
        }
        catch (Exception e)
        {
            return BadRequest("Error al obtener el usuario");
        }
    }

    
    [HttpGet]
    [Route("api/usuario/getAll")]
    public async Task<ActionResult<List<ResultadoLogin>>> GetUsuariosActivos()
    {
        try
        {
            var result = new List<ResultadoLogin>();
            
            var usuarios = await _context.Usuarios.Where(u =>
                u.Activo).Include(c =>c.IdRolNavigation).ToListAsync();

            if (usuarios !=null)
            {
                foreach (var usuario in usuarios)
                {
                    var resultadoAux = new ResultadoLogin
                    {
                        NombreUsuario = usuario.Nombre,
                        NombreRol = usuario.IdRolNavigation.Rol,
                        StatusCode = "200"
                    };
                    
                    result.Add(resultadoAux);
                }

                return Ok(result);
            }
            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest("Error al obtener el usuario");
        }
    }
}