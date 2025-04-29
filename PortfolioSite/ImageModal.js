// Function to initialize the modal functionality
function initialiseImageModal() {
    // Create modal elements
    const modalOverlay = document.createElement('div');
    modalOverlay.id = 'image-modal-overlay';
    modalOverlay.style.display = 'none';
    modalOverlay.innerHTML = `
        <div id="image-modal-content">
            <img id="image-modal-img" src="" alt="Modal Image" />
            <button id="image-modal-close">X</button>
        </div>
    `;
    document.body.appendChild(modalOverlay);

    // Add event listeners
    modalOverlay.addEventListener('click', (e) => {
        if (e.target === modalOverlay || e.target.id === 'image-modal-close') {
            closeModal();
        }
    });

    // Open modal function
    function openModal(imageSrc) {
        const modalImg = document.getElementById('image-modal-img');
        modalImg.src = imageSrc;
        modalOverlay.style.display = 'flex';
    }

    // Close modal function
    function closeModal() {
        modalOverlay.style.display = 'none';
    }

    // Use event delegation to handle clicks on images with the 'clickable-image' class
    document.addEventListener('click', (e) => {
        if (e.target.classList.contains('clickable-image')) {
            openModal(e.target.src);
        }
    });
}

// Export the function to be used in other files
export default initialiseImageModal;