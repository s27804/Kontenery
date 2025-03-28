// See https://aka.ms/new-console-template for more information

using Containers;

ContainerShip containerShip = new ContainerShip(100, 100, 200000);
FluidContainer fluidContainer = new FluidContainer(0, 259.1,2150,605.8,'L',28000,true);
fluidContainer.LoadCargo(20000);
fluidContainer.LoadCargo(14000);
Console.WriteLine(fluidContainer.ToString());
containerShip.LoadContainer(fluidContainer);

containerShip.PrintContainerList();

FluidContainer fluidContainer2 = new FluidContainer(0, 259.1,2150,605.8,'L',28000,true);
containerShip.ReplaceExistingContainer("KON-L-3",fluidContainer2);

containerShip.LoadContainer(fluidContainer2);

containerShip.PrintContainerList();

FluidContainer fluidContainer3 = new FluidContainer(0, 259.1,2150,605.8,'L',28000,true);
containerShip.ReplaceExistingContainer("KON-L-1",fluidContainer3);

containerShip.PrintContainerList();

Console.WriteLine(containerShip.ToString());

containerShip.UnloadContainer(fluidContainer2);

containerShip.PrintContainerList();

fluidContainer.DumpCargo();

ContainerShip containerShip2 = new ContainerShip(100, 100, 200000);

fluidContainer3.ReloadContainer(containerShip, containerShip2);

containerShip.PrintContainerList();
containerShip2.PrintContainerList();

Console.WriteLine(fluidContainer3.ToString());