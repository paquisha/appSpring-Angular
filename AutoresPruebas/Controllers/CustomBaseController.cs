﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoresPruebas.Controllers;
public class CustomBaseController : ControllerBase
{
    protected string ObtenerUsuarioId()
    {
        var usuarioClaim = HttpContext.User.Claims.Where(x => x.Type == "id").FirstOrDefault();
        var usuarioId = usuarioClaim.Value;
        return usuarioId;
    }
}
