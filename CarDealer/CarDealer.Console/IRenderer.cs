using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Console
{
    public interface IRenderer
    {
        public Task RenderAddCar();

        public Task RenderRemoveCarById();

        public Task RenderCarDetailsById();

        public Task RenderPreviewAllCars();

        public Task RenderSearchCarByMakeAndModel();

        public Task RenderTopThreePowerful();

        public Task RenderEditCar();

        public Task Exit();

        public Task RenderMainMenu();
    }
}
