import React, { useEffect, useState } from "react";
import api from "../services/api";
import { Income } from "../types/finance";

const Dashboard: React.FC = () => {
  const [incomes, setIncomes] = useState<Income[]>([]);

 useEffect(() => {
  api.get("/Finance/incomes")
    .then(res => setIncomes(res.data))
    .catch(err => console.error(err));
}, []);

  return (
    <div>
      <h1>Finance Dashboard</h1>
      {incomes.length === 0 ? (
        <p>No income data found</p>
      ) : (
        <ul>
          {incomes.map((i) => (
            <li key={i.id}>
              {i.source} — ₹{i.amount} on {new Date(i.date).toLocaleDateString()}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default Dashboard;
