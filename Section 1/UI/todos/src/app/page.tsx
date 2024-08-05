import { Todo, columns } from "./todos/columns"
import { DataTable } from "./todos/data-table"

async function getData(): Promise<Todo[]> {
  const response = await fetch("http://localhost:5078/api/todos");
  const data = await response.json();

  return data;
}

export default async function Home() {
  const data = await getData()

  return (
    <div>
      <DataTable columns={columns} data={data} />
    </div>
  );
}
