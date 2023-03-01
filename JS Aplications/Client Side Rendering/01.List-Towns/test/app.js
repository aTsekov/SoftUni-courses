import { html } from 'lit-html';

const rowTemplate = (id, name, email) => html`
  <tr>
    <td>${id}</td>
    <td>${name}</td>
    <td>${email}</td>
  </tr>
`;
const container = document.createElement('table');

const onSubmit = (event) => {
    event.preventDefault();
  
    const formData = new FormData(event.target);
    const id = formData.get('id');
    const name = formData.get('name');
    const email = formData.get('email');
  
    const newRow = rowTemplate(id, name, email);
    container.appendChild(newRow);
  
    // Clear the form fields
    event.target.reset();
  }

  const form = document.querySelector('form');
form.addEventListener('submit', onSubmit);


document.body.appendChild(container);
