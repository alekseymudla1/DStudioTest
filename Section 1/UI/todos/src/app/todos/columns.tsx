"use client"

import { ColumnDef } from "@tanstack/react-table"

export type Todo = {
    id: string;
    name: string;
    description: string;
    status: string;
    creationDate: string;
    lastModifiedDate: string;
}

export const columns: ColumnDef<Todo>[] = [
    {
      accessorKey: "name",
      header: "Name",
    },
    {
      accessorKey: "description",
      header: "Description",
    },
    {
      accessorKey: "status",
      header: "Status",
    },
    {
      accessorKey: "creationDate",
      header: "Creation Date",
    },
    {
      accessorKey: "lastModifiedDate",
      header: "Last Modified Date",
    },
  ]
