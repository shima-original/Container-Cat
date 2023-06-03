﻿using Container_Cat.Containers.EngineAPI.Models;
using Container_Cat.Containers.Models;
using Container_Cat.Models;
using Container_Cat.Podman_libpod_API;
using Container_Cat.Podman_libpod_API.Models;
using Container_Cat.Utilities;
using Container_Cat.Utilities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace Container_Cat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            SystemDataGathering dataGatherer = new SystemDataGathering();
            List<HostAddress> Hosts = new List<HostAddress>()
            {
                new HostAddress("127.0.0.1", "2375"),
                new HostAddress("192.168.56.99", "3375"),
                new HostAddress("192.168.0.104", "3375"),
                new HostAddress("google.com", "80") 
            };
            //Convert list of hosts in system lists here: ...
            List<SystemDataObj> dataObj = new List<SystemDataObj>();
            var tasks = Hosts.Select(async host =>
            {
                SystemDataObj item = new SystemDataObj(host);
                item.InstalledContainerEngines = await dataGatherer.ContainerEngineInstalledAsync(host);
                dataObj.Add(item);
            });
            await Task.WhenAll(tasks);
            var DockerHosts = dataObj
                .Where(item => item.InstalledContainerEngines == ContainerEngine.Docker)
                .Select(host => host.NetworkAddress)
                .ToList();
            var PodmanHosts = dataObj
                .Where(item => item.InstalledContainerEngines == ContainerEngine.Podman)
                .Select(host => host.NetworkAddress)
                .ToList();
            SystemOperations<DockerContainer> DockerSystems = new SystemOperations<DockerContainer>(DockerHosts);
            SystemOperations<PodmanContainer> PodmanSystems = new SystemOperations<PodmanContainer>(PodmanHosts);
            var systems = await DockerSystems.InitialiseHostSystemsAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}