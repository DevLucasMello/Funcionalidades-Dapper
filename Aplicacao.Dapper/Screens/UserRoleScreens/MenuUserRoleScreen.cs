using System;

namespace Aplicacao.Dapper.Screens.UserRoleScreens
{
    public static class MenuUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular perfil/usuário");
            Console.WriteLine("-----------------");
            CreateUserRoleScreen.Load();           
            Program.Load();            
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
