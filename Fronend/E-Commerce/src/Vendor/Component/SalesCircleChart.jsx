import React, { useState } from "react";
import {
  RadialBarChart,
  RadialBar,
  Legend,
  ResponsiveContainer
} from "recharts";

const monthlySales = {
  Jan: 65,
  Feb: 75,
  Mar: 85,
  Apr: 60,
  May: 90,
  Jun: 70,
  Jul: 80,
  Aug: 88,
  Sep: 76,
  Oct: 92,
  Nov: 95,
  Dec: 78
};

const SalesCircleChart = () => {

  const [month, setMonth] = useState("Jan");

  const data = [
    {
      name: "Sales",
      value: monthlySales[month],
      fill: "#f97316"
    }
  ];

  return (
    <div className="bg-white p-6 rounded-lg shadow w-full">

      <div className="flex justify-between mb-4">

        <h2 className="font-semibold">Monthly Sales</h2>

        <select
          className="border px-3 py-1 rounded"
          value={month}
          onChange={(e) => setMonth(e.target.value)}
        >
          {Object.keys(monthlySales).map((m) => (
            <option key={m}>{m}</option>
          ))}
        </select>

      </div>

      <ResponsiveContainer width="100%" height={250}>
        <RadialBarChart
          innerRadius="70%"
          outerRadius="100%"
          data={data}
          startAngle={90}
          endAngle={-270}
        >
          <RadialBar
            minAngle={15}
            background
            clockWise
            dataKey="value"
          />
          <Legend />
        </RadialBarChart>
      </ResponsiveContainer>

      <div className="text-center mt-3">
        <p className="text-3xl font-bold">{monthlySales[month]}%</p>
        <p className="text-gray-500">Sales Performance</p>
      </div>

    </div>
  );
};

export default SalesCircleChart;