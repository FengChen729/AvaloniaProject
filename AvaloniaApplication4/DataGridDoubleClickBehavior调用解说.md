介绍：
DataGridDoubleClickBehavior是一个用来在DataGrid表格中处理双击事件的行为类

其中包含两个重要方法：
1.双击判断（0.3s内连续点击认定为双击）
2.对应列识别，只用用户点击指定的某些列才能实现跳转

调用：
先创建一个Behaviors文件夹将DataGridDoubleClickBehavior类放入其中，然后给需要双击操作的表格命名为“xx”

    //.axaml
    <DataGrid x:Name="DataGird">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Signal Name" Binding="{Binding SignalName}" />
        </DataGrid.Columns>
    </DataGrid>

    //axaml.cs
    var grid = this.FindControl<DataGrid>("DataGrid");
    if (grid != null)
    {
        DataGridDoubleClickBehavior.SetOnDoubleClick(grid, signalObj =>
        {
            if (signalObj is CanSignal signal)
            {
                var editWindow = new EditSignalWindow(signal);
                editWindow.Show();
            }
        });
        DataGridDoubleClickBehavior.SetTargetColumnHeaders(DataGrid, new []{"Signal Name"});
    }
