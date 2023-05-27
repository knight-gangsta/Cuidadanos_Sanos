﻿using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Models;
using System.Collections.Generic;

namespace Ciudadanos_Sanos.Data
{
	public class SanoContext : DbContext
	{
		public SanoContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Medico> Medico { get; set; }
		public DbSet<Paciente> Paciente { get; set; }
		public DbSet<RegistroCita> RegistroCita { get; set; }
		//public DbSet<Usuario> Usuario { get; set; }
	}
}
