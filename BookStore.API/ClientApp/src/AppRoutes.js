import BookManager from "./components/BookManager";
import BookDetail from "./components/BookDetail";
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path:'/book-manager',
    element: <BookManager/>
  },
  {
    path: '/books/:id', 
    element: <BookDetail />
  },
];

export default AppRoutes;
