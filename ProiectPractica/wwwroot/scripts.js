namespace ProiectPractica.wwwroot
{
    window.getSelectedValues = (selectId) => {
        const selectElement = document.getElementById(selectId);
        if (!selectElement) {
            console.error(`Element with ID '${selectId}' not found.`);
            return [];
        }
        return Array.from(selectElement.selectedOptions).map(option => parseInt(option.value));
    };
}
