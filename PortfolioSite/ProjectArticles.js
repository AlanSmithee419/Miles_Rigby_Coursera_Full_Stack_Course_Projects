let projectArticleList = [
    [
        "skills-development", 

        `<article>
            <h4>Simple Coursera Projects</h4>
            <p>
                I've made a couple of small programming projects during a full-stack development
                course on Coursera, which I am currently continuing to progress through. So far,
                I have completed three projects - a simple console-based stock tracker, and a
                less complex, but more object-oriented with effective seperation of tasks, library 
                manager. Finally this website itself is my most recent completed project for this
                course.
            </p>
            <figure class="no-gap-image">
                <img class="basic-image clickable-image" id="stock-manager-demo-image-2" src="StockManagerDemo2.png" alt="
                Image showing a stock management system running in a linux console, showing different 
                functionality such as creating new items, setting stock quantities, processing stock 
                changes due to purchases or sales, and looking up specific items as well displaying 
                all stock information." />
                <figcaption class="basic-caption">
                    Screenshot of the stock manager in operation
                </figcaption>
            </figure>
        </article>`
    ],

    [
        "personal-projects",

        `<article>
            <h4>Incremental Game in Unity</h4>
            <p>
                A purely UI-based incremental game in a survival fantasy setting. The game is built
                in C# using Unity, and version control through GitHub and VSCode. The idea is to use
                this project to create a fun experience while developing my abilities with the basics of
                Unity and in particular menu-based UI and navigation, before moving to more complex
                projects.
            </p>
            <figure>
                <img class="basic-image clickable-image" src="UnityIncrementalDemo.png" alt="An image showing a simple UI for a game, consisting of player skills, along with resources and craftable items" />
                <figcaption class="basic-caption">
                    Main screen of the incremental game built in Unity
                </figcaption>
            </figure> 
        </article>`
    ]
];

let FilterProjects = function() {
    let filterMenu = document.getElementById("filter-menu");

    let filterList = [];
    let checkboxList = filterMenu.querySelectorAll("input[type='checkbox']");

    checkboxList.forEach(checkbox => {
        if (checkbox.checked) {
            filterList.push(checkbox.value);
        }
    });

    let projectArticlesDiv = document.getElementById("project-articles");
    let projectArticlesContent = ``;

    if (filterList.length === 0) {
        projectArticleList.forEach(([category, article]) => {
            projectArticlesContent += article + `\n`;
        });
    } else {

        filterList.forEach(filter => {
            projectArticleList.forEach(([category, article]) => {
                if (category === filter){
                    projectArticlesContent += article + `\n`;
                }
            });
        });

    }

    projectArticlesDiv.innerHTML = projectArticlesContent;
};

export default FilterProjects;