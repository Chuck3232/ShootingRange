using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShootingRange.Extensions
{
	public static class ClaimsPrincipalExtensions
	{
		public static Guid GetUserId(this ClaimsPrincipal user)
		{
			return Guid.Parse(user.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
		}
	}
}
