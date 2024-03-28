import { BarChart } from '@mui/x-charts/BarChart';
import React, { useState } from 'react';
import { useLocation } from 'react-router-dom';

const Corona = () => {
  const { state } = useLocation()
  console.log(state)
  let personalDetails = state.details
  const now = new Date()
  const prevMonth = new Date(now.getFullYear(), now.getMonth() - 1)
  const numDays = new Date(prevMonth.getFullYear(), prevMonth.getMonth() + 1, 0).getDate()
  let temp = []
  let count

  for (let i = 1; i <= numDays; i++) {
    const date = new Date(prevMonth.getFullYear(), prevMonth.getMonth(), i);
    count = 0;
    personalDetails.forEach(p => {
      Date.parse(p.coronaDetails.dataSick) <= Date.parse(date) && Date.parse(p.coronaDetails.dataRecover) > Date.parse(date) && count++
    });
    temp.push(count)
  }
  const [arr, setArr] = useState([0, ...temp]);

  let countNotVaccinated = 0;
  personalDetails.forEach(p => {
    p.coronaDetails.firstVaccination == null && countNotVaccinated++;
  });
  const [notVaccinated, setNotVaccinated] = useState(countNotVaccinated);

  return (
    <>
      <h2>number of sick people last month</h2>
      {arr && <BarChart
        series={[
          { data: arr },
        ]}
        height={290}
        xAxis={[{ data: [...Array(numDays).keys()].map(i => i + 1), scaleType: 'band' }]}
        margin={{ top: 10, bottom: 30, left: 40, right: 10 }}
      />}
      <p> {notVaccinated} patients were not vaccinated against Corona Virus</p>
    </>
  );
}
export default Corona;
