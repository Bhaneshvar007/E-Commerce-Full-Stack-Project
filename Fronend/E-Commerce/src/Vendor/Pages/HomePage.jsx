import React, { useState } from "react";
import VendoreNavbar from "../Component/VendoreNavbar";
import {
  XAxis,
  YAxis,
  Tooltip,
  CartesianGrid,
  ResponsiveContainer,
  BarChart,
  Bar,
  Legend
} from "recharts";

const yearlyData = {
  2023: [
    { month: "Jan", buy: 30, sell: 20 },
    { month: "Feb", buy: 50, sell: 35 },
    { month: "Mar", buy: 60, sell: 45 },
    { month: "Apr", buy: 40, sell: 30 },
    { month: "May", buy: 70, sell: 55 },
    { month: "Jun", buy: 90, sell: 70 },
    { month: "Jul", buy: 85, sell: 60 },
    { month: "Aug", buy: 80, sell: 65 },
    { month: "Sep", buy: 75, sell: 55 },
    { month: "Oct", buy: 95, sell: 75 },
    { month: "Nov", buy: 100, sell: 80 },
    { month: "Dec", buy: 110, sell: 90 }
  ],

  2024: [
    { month: "Jan", buy: 40, sell: 30 },
    { month: "Feb", buy: 60, sell: 45 },
    { month: "Mar", buy: 80, sell: 60 },
    { month: "Apr", buy: 50, sell: 35 },
    { month: "May", buy: 90, sell: 70 },
    { month: "Jun", buy: 100, sell: 85 },
    { month: "Jul", buy: 95, sell: 80 },
    { month: "Aug", buy: 100, sell: 85 },
    { month: "Sep", buy: 90, sell: 70 },
    { month: "Oct", buy: 110, sell: 95 },
    { month: "Nov", buy: 120, sell: 100 },
    { month: "Dec", buy: 130, sell: 110 }
  ]
};

const HomePage = () => {

  const [year, setYear] = useState("2024");

  return (
    <div className="flex">

      <VendoreNavbar />

      <div className="p-8 w-full bg-gray-50">

        <h1 className="text-2xl font-bold mb-6">Dashboard</h1>

        {/* Top Cards */}

        <div className="grid grid-cols-4 gap-6 mb-8">

          <div className="bg-white p-6 rounded-lg shadow">
            <h2 className="text-gray-500">Total Sales</h2>
            <p className="text-2xl font-bold">1,058</p>
          </div>

          <div className="bg-white p-6 rounded-lg shadow">
            <h2 className="text-gray-500">Total Orders</h2>
            <p className="text-2xl font-bold">1,240</p>
          </div>

          <div className="bg-white p-6 rounded-lg shadow">
            <h2 className="text-gray-500">Monthly Buy</h2>
            <p className="text-2xl font-bold">560</p>
          </div>

          <div className="bg-white p-6 rounded-lg shadow">
            <h2 className="text-gray-500">Monthly Sell</h2>
            <p className="text-2xl font-bold">430</p>
          </div>

        </div>

        {/* Chart Section */}

        <div className="grid gap-6">

          <div className="bg-white p-6 rounded-lg shadow">

            <div className="flex justify-between items-center mb-4">

              <h2 className="font-semibold">Monthly Buy / Sell</h2>

              <select
                value={year}
                onChange={(e) => setYear(e.target.value)}
                className="border px-3 py-1 rounded"
              >
                {Object.keys(yearlyData).map((y) => (
                  <option key={y}>{y}</option>
                ))}
              </select>

            </div>

            <ResponsiveContainer width="100%" height={300}>
              <BarChart data={yearlyData[year]}>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="month" />
                <YAxis />
                <Tooltip />
                <Legend />

                <Bar dataKey="buy" fill="#3b82f6" name="Buy" />
                <Bar dataKey="sell" fill="#22c55e" name="Sell" />

                 

              </BarChart>
            </ResponsiveContainer>

          </div>

        </div>

      </div>
    </div>
  );
};

export default HomePage;