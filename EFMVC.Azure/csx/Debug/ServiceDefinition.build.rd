<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="EFMVC.Azure" generation="1" functional="0" release="0" Id="721ede42-b741-4517-b369-aa4bb1caff83" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="EFMVC.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="EFMVC.Web:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/LB:EFMVC.Web:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" />
          </maps>
        </aCS>
        <aCS name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" />
          </maps>
        </aCS>
        <aCS name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.Loglevel" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.Loglevel" />
          </maps>
        </aCS>
        <aCS name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" />
          </maps>
        </aCS>
        <aCS name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="EFMVC.CacheWorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.CacheWorkerRoleInstances" />
          </maps>
        </aCS>
        <aCS name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" />
          </maps>
        </aCS>
        <aCS name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" />
          </maps>
        </aCS>
        <aCS name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.Loglevel" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.Loglevel" />
          </maps>
        </aCS>
        <aCS name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" />
          </maps>
        </aCS>
        <aCS name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="EFMVC.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:EFMVC.Web:Endpoint1">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Endpoint1" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" />
          </toPorts>
        </sFSwitchChannel>
        <sFSwitchChannel name="SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" />
          </toPorts>
        </sFSwitchChannel>
        <sFSwitchChannel name="SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" />
          </toPorts>
        </sFSwitchChannel>
        <sFSwitchChannel name="SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" />
          </toPorts>
        </sFSwitchChannel>
        <sFSwitchChannel name="SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" />
          </toPorts>
        </sFSwitchChannel>
        <sFSwitchChannel name="SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" />
          </toPorts>
        </sFSwitchChannel>
        <sFSwitchChannel name="SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" />
          </toPorts>
        </sFSwitchChannel>
        <sFSwitchChannel name="SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" />
          </toPorts>
        </sFSwitchChannel>
        <sFSwitchChannel name="SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" />
          </toPorts>
        </sFSwitchChannel>
        <sFSwitchChannel name="SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" />
          </setting>
        </map>
        <map name="MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" />
          </setting>
        </map>
        <map name="MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.Loglevel" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Caching.Loglevel" />
          </setting>
        </map>
        <map name="MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" />
          </setting>
        </map>
        <map name="MapEFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapEFMVC.CacheWorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRoleInstances" />
          </setting>
        </map>
        <map name="MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" />
          </setting>
        </map>
        <map name="MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" />
          </setting>
        </map>
        <map name="MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.Loglevel" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Caching.Loglevel" />
          </setting>
        </map>
        <map name="MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" />
          </setting>
        </map>
        <map name="MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapEFMVC.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="EFMVC.CacheWorkerRole" generation="1" functional="0" release="0" software="D:\GitHub\EFMVC.Azure\EFMVC.Azure\csx\Debug\roles\EFMVC.CacheWorkerRole" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" protocol="tcp" />
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Caching.Loglevel" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;EFMVC.CacheWorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;EFMVC.CacheWorkerRole&quot;&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;EFMVC.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="Microsoft.WindowsAzure.Plugins.Caching.FileStore" defaultAmount="[1000,1000,1000]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRoleInstances" />
            <sCSPolicyFaultDomainMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.CacheWorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="EFMVC.Web" generation="1" functional="0" release="0" software="D:\GitHub\EFMVC.Azure\EFMVC.Azure\csx\Debug\roles\EFMVC.Web" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" protocol="tcp" />
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.CacheWorkerRole:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal" />
                </outToChannel>
              </outPort>
              <outPort name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/SW:EFMVC.Web:Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Caching.CacheSizePercentage" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Caching.ConfigStoreConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Caching.Loglevel" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Caching.NamedCaches" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;EFMVC.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;EFMVC.CacheWorkerRole&quot;&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;EFMVC.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheArbitrationPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheClusterPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheReplicationPort&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheServicePortInternal&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.Caching.cacheSocketPort&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="Microsoft.WindowsAzure.Plugins.Caching.FileStore" defaultAmount="[1000,1000,1000]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.WebInstances" />
            <sCSPolicyFaultDomainMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.WebFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="EFMVC.CacheWorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyFaultDomain name="EFMVC.WebFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="EFMVC.CacheWorkerRoleInstances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="EFMVC.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="20928573-2446-4fda-8455-a909c4b48d02" ref="Microsoft.RedDog.Contract\ServiceContract\EFMVC.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="a58d8762-9f16-434e-b244-5537693f239f" ref="Microsoft.RedDog.Contract\Interface\EFMVC.Web:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>