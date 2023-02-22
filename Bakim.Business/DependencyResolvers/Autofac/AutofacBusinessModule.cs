using Autofac;
using Autofac.Extras.DynamicProxy;
using Bakim.Business.Abstracts;
using Bakim.Business.Concrete;
using Bakim.Business.Concreteck;
using Bakim.Core.Utilities.Helpers.File;
using Bakim.Core.Utilities.Interceptors;
using Bakim.Dataaccess.Abstracts;
using Bakim.Dataaccess.Concrete;
using Castle.DynamicProxy;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SectionManager>().As<ISectionService>().SingleInstance();
            builder.RegisterType<SectionDal>().As<ISectionDal>().SingleInstance();

            builder.RegisterType<SectionFaultManager>().As<ISectionFaultService>().SingleInstance();
            builder.RegisterType<SectionFaultDal>().As<ISectionFaultDal>().SingleInstance();

            builder.RegisterType<WorkTaskUserManager>().As<IWorkTaskUserService>().SingleInstance();
            builder.RegisterType<WorkTaskUserDal>().As<IWorkTaskUserDal>().SingleInstance();

            builder.RegisterType<WorkTaskTransferManager>().As<IWorkTaskTransferService>().SingleInstance();
            builder.RegisterType<WorkTaskTransferDal>().As<IWorkTaskTransferDal>().SingleInstance();

            builder.RegisterType<WorkTaskManager>().As<IWorkTaskService>().SingleInstance();
            builder.RegisterType<WorkTaskDal>().As<IWorkTaskDal>().SingleInstance();

            builder.RegisterType<CallManager>().As<ICallService>().SingleInstance();
            builder.RegisterType<CallDal>().As<ICallDal>().SingleInstance();

            builder.RegisterType<ProductionSectionManager>().As<IProductionSectionService>().SingleInstance();
            builder.RegisterType<ProductionSectionDal>().As<IProductionSectionDal>().SingleInstance();

            builder.RegisterType<MachineManager>().As<IMachineService>().SingleInstance();
            builder.RegisterType<MachineDal>().As<IMachineDal>().SingleInstance();

            builder.RegisterType<UserAnnouncementManager>().As<IUserAnnouncementService>();
            builder.RegisterType<UserAnnouncementDal>().As<IUserAnnouncementDal>();

            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>().SingleInstance();
            builder.RegisterType<AnnouncementDal>().As<IAnnouncementDal>().SingleInstance();

            builder.RegisterType<CorporationManager>().As<ICorporationService>().SingleInstance();
            builder.RegisterType<CorporationDal>().As<ICorporationDal>().SingleInstance();


            builder.RegisterType<FileManager>().As<IFileService>().SingleInstance();
            builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();


            builder.RegisterType<RoutineBakimDal>().As<IRoutinBakimDal>().SingleInstance();
            builder.RegisterType<RoutineBakimManager>().As<IRoutineBakimService>().SingleInstance();

            builder.RegisterType<RoutineBakimMakineDal>().As<IRoutineBakimMakineDal>().SingleInstance();
            builder.RegisterType<RoutineBakimMakineManager>().As<IRoutineBakimMakineService>().SingleInstance();

            builder.RegisterType<RoutineBakimDetayDal>().As<IRoutinBakimDetayDal>().SingleInstance();
            builder.RegisterType<RoutineBakimDetayManager>().As<IRoutineBakimDetayService>().SingleInstance();

            builder.RegisterType<StockDal>().As<IStockDal>().SingleInstance();
            builder.RegisterType<StockManager>().As<IStockService>().SingleInstance();

            builder.RegisterType<StockGroupDal>().As<IStockGroupDal>().SingleInstance();
            builder.RegisterType<StockGroupManager>().As<IStockGroupService>().SingleInstance();

            builder.RegisterType<VarlikGroupDal>().As<IVarlikGroupDal>().SingleInstance();
            builder.RegisterType<VarlikGroupManager>().As<IVarlikGroupService>().SingleInstance();

            builder.RegisterType<CalendarDal>().As<ICalendarDal>().SingleInstance();
            builder.RegisterType<CalendarManager>().As<ICalendarService>().SingleInstance();

            builder.RegisterType<RoutineBakimTuruDal>().As<IRoutineBakimTuruDal>().SingleInstance();
            builder.RegisterType<RoutineBakimTuruManager>().As<IRoutineBakimTuruService>().SingleInstance();

            builder.RegisterType<DetayGroupDal>().As<IDetayGroupDal>().SingleInstance();
            builder.RegisterType<DetayGroupManager>().As<IDetayGroupService>().SingleInstance();

            builder.RegisterType<StokKategoriDal>().As<IStokKategoriDal>().SingleInstance();
            builder.RegisterType<StokKategoriManager>().As<IStokKategoriService>().SingleInstance();

            builder.RegisterType<TedarikciFirmaDal>().As<ITedarikciFirmaDal>().SingleInstance();
            builder.RegisterType<TedarikciFirmaManager>().As<ITedarikciFirmaService>().SingleInstance();

            builder.RegisterType<VarlikDal>().As<IVarlikDal>().SingleInstance();
            builder.RegisterType<VarlikManager>().As<IVarlikService>().SingleInstance();

            builder.RegisterType<Stok_FirmaDal>().As<IStok_FirmaDal>().SingleInstance();
            builder.RegisterType<Stok_FirmaManager>().As<IStok_FirmaService>().SingleInstance();

            builder.RegisterType<BirimDal>().As<IBirimDal>().SingleInstance();
            builder.RegisterType<BirimManager>().As<IBirimService>().SingleInstance();

            builder.RegisterType<TalepDal>().As<ITalepDal>().SingleInstance();
            builder.RegisterType<TalepManager>().As<ITalepService>().SingleInstance();

            
                        
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            });
        }
    }
}
