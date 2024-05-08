@Imports RSATask.Domain.Models

@ModelType IEnumerable(Of WeatherForecast)

@Code
    ViewBag.Title = "Weather Forecast"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div class="container mt-5">
    <div class="row">
        <div class="col-md-7">
            <h3 class="d-inline-block">Weather Forecast Results</h3>
        </div>
        <div class="col-md-5 text-right">
            <a class="btn btn-outline-primary" href="@Url.Action("Upload", "ForecastWeather")">New Weather Forecast</a>
        </div>
    </div>
    <hr />
    <i class="fa fa-address-book-o" aria-hidden="true"></i>


    @If Model.Count() > 0 Then
        @<marquee direction="right" behavior="scroll" scrollamount="7">
            Here are the results of your weather forecasts
        </marquee>
        @<div class="row mt-3">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">
                            <i class="fas fa-thermometer-full"></i>
                            Highest Temperature
                        </h5>
                        <p>
                            @Model.Max(Function(x) x.max_temperature.Split(","c).Select(Function(temp) Convert.ToDouble(temp.Trim())).Max()) °C
                        </p>
                    </div>
                </div>
            </div>
            <div Class="col-md-4">
                <div Class="card">
                    <div Class="card-body">
                        <h5 Class="card-title"><i class="fas fa-thermometer-empty"></i> Lowest Temperature</h5>
                        <p>
                            @Model.Max(Function(x) x.min_temperature.Split(","c).Select(Function(temp) Convert.ToDouble(temp.Trim())).Max()) °C
                        </p>
                    </div>
                </div>
            </div>
            <div Class="col-md-4">
                <div Class="card">
                    <div Class="card-body">
                        <h5 Class="card-title"><i class="fas fa-list"></i> Total Records</h5>
                        <p Class="card-text">
                            @Model.Count() Records
                        </p>
                    </div>
                </div>
            </div>
        </div>
        @<div Class="table-responsive mt-4">
            <Table Class="table table-bordered table-hover">
                <thead Class="thead-light">
                    <tr>
                        <th scope="col"> Location Name <i Class="bi bi-sort-alpha-up"></i></th>
                        <th scope="col"> Longitude <i Class="bi bi-sort-alpha-up"></i></th>
                        <th scope="col"> Latitude <i Class="bi bi-sort-alpha-up"></i></th>
                        <th scope="col"> Min Temp. <i Class="bi bi-sort-alpha-up"></i></th>
                        <th scope="col"> Max Temp. <i Class="bi bi-sort-alpha-up"></i></th>
                        <th scope="col"> Date <i Class="bi bi-sort-alpha-up"></i></th>
                        <th scope="col"> Sunrise <i Class="bi bi-sort-alpha-up"></i></th>
                        <th scope="col"> Sunset <i Class="bi bi-sort-alpha-up"></i></th>

                    </tr>
                </thead>
                <tbody>
                    @For Each item In Model
                        @<tr>
                            <td>@item.location_name</td>
                            <td>@item.longitude</td>
                            <td>@item.latitude</td>
                            <td>
                                <ul>
                                    @For Each min_temp In item.min_temperature.Split(","c)
                                        @<li>@min_temp °C</li>
                                    Next
                                </ul>
                            </td>
                            <td>
                                <ul>
                                    @For Each max_temp In item.max_temperature.Split(","c)
                                        @<li>@max_temp °C</li>
                                    Next
                                </ul>
                            </td>
                            <td>
                                <ul>
                                    @For Each sunrise In item.sunrise.Split(","c)
                                        @<li>@DateTime.Parse(sunrise).ToLongDateString()</li>
                                    Next
                                </ul>
                            </td>
                            <td>
                                <ul>
                                    @For Each sunrise In item.sunrise.Split(","c)
                                        @<li>@DateTime.Parse(sunrise).ToLongTimeString()</li>
                                    Next
                                </ul>
                            </td>
                            <td>
                                <ul>
                                    @For Each sunset In item.sunset.Split(","c)
                                        @<li>@DateTime.Parse(sunset).ToLongTimeString()</li>
                                    Next
                                </ul>
                            </td>
                        </tr>
                    Next
                </tbody>
            </Table>
        </div>
    Else
        @<marquee direction="right" behavior="scroll" scrollamount="7">
            Sorry !!!  There are no weather forecast results To show at time.
        </marquee>
        @<div class="alert alert-info" role="alert">

            No weather forecast records found.
        </div>
    End If
    @* Pagination code can be added here if needed *@
</div>