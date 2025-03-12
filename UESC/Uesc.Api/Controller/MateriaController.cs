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



        public  MateriaController(IMateriaService materiaService, IMateriaRepository materiaRepository)
        {
            _materiaService = materiaService;
            _materiaRepository = materiaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MateriaViewModel>>> Get()
        {
            //return await  _materiaService.ListarMaterias();
            return await _materiaRepository.ListarMaterias();
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<MateriaViewModel>> Get(int id)
        {
           //return await _materiaService.BuscarMateriaPorId(id);
           return await _materiaRepository.BuscarMateriaPorId(id);
        }

        [HttpPost]
        public async Task <ActionResult<MateriaViewModel>> Post([FromBody] MateriaInputModel materia)
        {
            return  await _materiaService.InserirMateria(materia);
        }

        [HttpPut("{id}")]
        public async Task <ActionResult<MateriaViewModel>> Put(int id, [FromBody] UpdateMateriaInputModel materia)
        {
            return await _materiaService.AtualizarMateria(id, materia);
        }

        [HttpDelete("{id}")]
        public async Task <ActionResult<MateriaViewModel>> Delete(int id)
        {
            return await _materiaService.RemoverMateria(id);
        }
        

    }
}
