function getDiscussionGraphData(id, category, timemin, timemax) {
    // Create the graph class
    const graph = new DatasetGraph('#' + id);

    graph.load(category, timemin, timemax, () => {
        graph.showTitle(true);
    });
}