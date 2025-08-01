﻿using ecommerce.api.Common;
using ecommerce.Application.Cqrs.Carts.Commands.CreateCart;
using ecommerce.Application.Cqrs.Carts.Queries;
using ecommerce.Application.Cqrs.Carts.Queries.GetQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.api.Controllers;

public class CartController : BaseController
{
    public CartController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCart([FromBody]CreateCartCommand command)
    {
        var result =await mediator.Send(command);
        return new JsonResult(result);
    }

    [HttpGet("[action]/{Id}")]
    public async Task<IActionResult> Get([FromRoute]GetCartQuery query)
    {
        var response = await mediator.Send(query);
        return NewResult(response);
    }

    [HttpDelete("[action]/{Id}")]
    public async Task<IActionResult> Delete([FromRoute] GetCartQuery query)
    {
        var response = await mediator.Send(query);
        return NewResult(response);
    }
}