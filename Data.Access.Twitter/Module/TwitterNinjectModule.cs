using CadastroLivros.Domain.Repository;
using Data.Access.Twitter.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Twitter.Module
{
    public class TwitterNinjectModule : NinjectModule
    {
       public override void Load()
       {
           Bind<IPostRepository>().To<PostRepositoryTwitterImpl>();
       }

    }
}
