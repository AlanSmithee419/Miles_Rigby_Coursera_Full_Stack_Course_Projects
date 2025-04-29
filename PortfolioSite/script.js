import FilterProjects from './ProjectArticles.js';
import initialiseImageModal from './ImageModal.js';

initialiseImageModal();

let projectsFilterButton = document.getElementById("projects-filter-button");

projectsFilterButton.addEventListener("click", (event) => {
    event.preventDefault();
    FilterProjects();
});