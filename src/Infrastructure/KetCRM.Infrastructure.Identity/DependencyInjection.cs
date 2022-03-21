using KetCRM.Application.Interfaces;
using KetCRM.Application.Interfaces.Account;
using KetCRM.Domain.Settings;
using KetCRM.Infrastructure.Identity.Contexts;
using KetCRM.Infrastructure.Identity.Models;
using KetCRM.Infrastructure.Identity.Services;
using KetCRM.Infrastructure.Shared.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KetCRM.Infrastructure.Identity
{
    public static class DependencyInjection
    {
    }
}
