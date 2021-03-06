﻿
$.ajax({
   
    url: "/Manager/AveragePurchasePerMonth", success: function (result) {
        drawGraph(result);
    }
});

function drawGraph(data) {

    var margin = {
        top: 10,
        right: 30,
        bottom: 200,
        left: 90
    },

    width = 450 - margin.left - margin.right,
    height = 500 - margin.top - margin.bottom;

    //An ordinal scale, to support the bars, we choose 
    var x = d3.scale.ordinal()
      .rangeRoundBands([width, 0], 0.1);

    var y = d3.scale.linear()
      .range([0, height]);

    //Create an axis
    var xAxis = d3.svg.axis()
      .scale(x)
        //this is where the labels will be located
      .orient("bottom");

    var yAxis = d3.svg.axis()
       .scale(y)
       .orient("left")
        //Ticks are the divisions on the scale. 
       .tickFormat(d3.format("d"))
        //Here we want to see only whole numbers on the axis
       .tickSubdivide(0);


    var svg = d3.select("svg#barChart1")
      .attr("width", width + margin.left + margin.right)
      .attr("height", height + margin.top + margin.bottom)
      .append("g")
      .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    //The x domain is a map of all the Products names
    x.domain(data.map(function (d) {
        return d.Month;
    }));

    //The y domain is a range from the maximal (Count) value in the array until 0
    y.domain([d3.max(data, function (d) {
        return d.price;

    }), 0]);

    svg.append("g")
      .attr("class", "y axis")
      .attr("transform", "translate(0," + height + ")")
      .call(xAxis)
        //In some cases the labels will overlap
      .selectAll("text")
      .attr("transform", "rotate(90)")
      .attr("x", 0)
      .attr("y", -6)
      .attr("dx", ".6em")
      .style("text-anchor", "start");

    svg.append("g")
      .attr("class", "y axis")
      .call(yAxis);

    svg.selectAll(".bar")
      .data(data)
      .enter().append("rect")
      .attr("class", "bar")

      .attr("x", function (d) {
          //the x function, transforms the value, based on the scale
          return x(d.Month);
      })
        //The rangeBand() function returns the width of the bars
      .attr("width", x.rangeBand())
      .attr("y", function (d) {
          //the y function does the same
          return y(d.price);

      })
      .attr("height", function (d) {
          return height - y(d.price);
      });
}
