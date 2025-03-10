using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;
using Uesc.Business.IRepository;
using Uesc.Business.Services;

namespace Uesc.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;
        private readonly IMateriaRepository _materiaRepository;



        public MateriaController(IMateriaService materiaService, IMateriaRepository materiaRepository)
        {
            _materiaService = materiaService;
            _materiaRepository = materiaRepository;
        }

        [HttpGet]
        public ActionResult<List<MateriaViewModel>> Get()
        {
            //return Ok(_materiaService.ListarMaterias());
            return Ok(_materiaRepository.ListarMaterias());
        }

        [HttpGet("{id}")]
        public ActionResult<MateriaViewModel> Get(int id)
        {
           // return Ok(_materiaService.BuscarMateriaPorId(id));
            return Ok(_materiaRepository.BuscarMateriaPorId(id));
        }

        [HttpPost]
        public ActionResult<MateriaViewModel> Post([FromBody] MateriaInputModel materia)
        {
            return Ok(_materiaService.InserirMateria(materia));
        }

        [HttpPut("{id}")]
        public ActionResult<MateriaViewModel> Put(int id, [FromBody] UpdateMateriaInputModel materia)
        {
            return _materiaService.AtualizarMateria(id, materia);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_materiaService.RemoverMateria(id));
        }
        

    }
}
