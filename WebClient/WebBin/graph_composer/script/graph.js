/** @type {string} URL to the game server */
let urlGameServer = APPIQUERYURL;

let DatasetGraph = function (selector) {
    // ------ public members ------
    /** @type {string} unique ID of the current graph (null if none loaded) */
    this.id = '';

    /** @type {string} name of the current graph */
    this.name = '';

    /** @type {number} start of graph time */
    this.time_start = 0;
    this.time_end = 10000;

    /** @type {boolean} TRUE when the graph has been changed */
    this.modified = false;

    /* @type {float} craphic step */
    let graphicStep = 0.01;

    // ------ private members ------
    let chart;
    let chartType = 'spline';

    const colors = [
        "#63b598", "#ce7d78", "#ea9e70", "#a48a9e", "#c6e1e8", "#648177", "#0d5ac1",
        "#f205e6", "#1c0365", "#14a9ad", "#4ca2f9", "#a4e43f", "#d298e2", "#6119d0",
        "#d2737d", "#c0a43c", "#f2510e", "#651be6", "#79806e", "#61da5e", "#cd2f00",
        "#9348af", "#01ac53", "#c5a4fb", "#996635", "#b11573", "#4bb473", "#75d89e",
        "#2f3f94", "#2f7b99", "#da967d", "#34891f", "#b0d87b", "#ca4751", "#7e50a8",
        "#c4d647", "#e0eeb8", "#11dec1", "#289812", "#566ca0", "#ffdbe1", "#2f1179",
        "#935b6d", "#916988", "#513d98", "#aead3a", "#9e6d71", "#4b5bdc", "#0cd36d",
        "#250662", "#cb5bea", "#228916", "#ac3e1b", "#df514a", "#539397", "#880977",
        "#f697c1", "#ba96ce", "#679c9d", "#c6c42c", "#5d2c52", "#48b41b", "#e1cf3b",
        "#5be4f0", "#57c4d8", "#a4d17a", "#0225b8", "#be608b", "#96b00c", "#088baf",
        "#f158bf", "#e145ba", "#ee91e3", "#05d371", "#5426e0", "#4834d0", "#802234",
        "#6749e8", "#0971f0", "#8fb413", "#b2b4f0", "#c3c89d", "#c9a941", "#41d158",
        "#fb21a3", "#51aed9", "#5bb32d", "#0807fb", "#21538e", "#89d534", "#d36647",
        "#7fb411", "#0023b8", "#3b8c2a", "#986b53", "#f50422", "#983f7a", "#ea24a3",
        "#79352c", "#521250", "#c79ed2", "#d6dd92", "#e33e52", "#b2be57", "#fa06ec",
        "#1bb699", "#6b2e5f", "#64820f", "#01c271", "#21538e", "#89d534", "#d36647",
        "#7fb411", "#0023b8", "#3b8c2a", "#986b53", "#f50422", "#983f7a", "#ea24a3",
        "#79352c", "#521250", "#c79ed2", "#d6dd92", "#e33e52", "#b2be57", "#fa06ec",
        "#1bb699", "#6b2e5f", "#64820f", "#01c271", "#9cb64a", "#996c48", "#9ab9b7",
        "#06e052", "#e3a481", "#0eb621", "#fc458e", "#b2db15", "#aa226d", "#792ed8",
        "#73872a", "#520d3a", "#cefcb8", "#a5b3d9", "#7d1d85", "#c4fd57", "#f1ae16",
        "#8fe22a", "#ef6e3c", "#243eeb", "#01dc18", "#dd93fd", "#3f8473", "#e7dbce",
        "#421f79", "#7a3d93", "#635f6d", "#93f2d7", "#9b5c2a", "#15b9ee", "#0f5997",
        "#409188", "#911e20", "#1350ce", "#10e5b1", "#fff4d7", "#cb2582", "#ce00be",
        "#32d5d6", "#017232", "#608572", "#c79bc2", "#00f87c", "#77772a", "#6995ba",
        "#fc6b57", "#f07815", "#8fd883", "#060e27", "#96e591", "#21d52e", "#d00043",
        "#b47162", "#1ec227", "#4f0f6f", "#1d1d58", "#947002", "#bde052", "#e08c56",
        "#28fcfd", "#0bb09b", "#36486a", "#d02e29", "#1ae6db", "#3e464c", "#a84a8f",
        "#911e7e", "#3f16d9", "#0f525f", "#ac7c0a", "#b4c086", "#c9d730", "#30cc49",
        "#3d6751", "#fb4c03", "#640fc1", "#62c03e", "#d3493a", "#88aa0b", "#406df9",
        "#615af0", "#04be47", "#2a3434", "#4a543f", "#79bca0", "#a8b8d4", "#00efd4",
        "#7ad236", "#7260d8", "#1deaa7", "#06f43a", "#823c59", "#e3d94c", "#dc1c06",
        "#f53b2a", "#b46238", "#2dfff6", "#a82b89", "#1a8011", "#436a9f", "#1a806a",
        "#4cf09d", "#c188a2", "#67eb4b", "#b308d3", "#fc7e41", "#af3101", "#0ff065",
        "#71b1f4", "#a2f8a5", "#e23dd0", "#d3486d", "#00f7f9", "#474893", "#3cec35",
        "#1c65cb", "#5d1d0c", "#2d7d2a", "#ff3420", "#5cdd87", "#a259a4", "#e4ac44",
        "#1bede6", "#8798a4", "#d7790f", "#b2c24f", "#de73c2", "#d70a9c", "#025b67",
        "#88e9b8", "#c2b0e2", "#86e98f", "#ae90e2", "#1a806b", "#436a9e", "#0ec0ff",
        "#f812b3", "#b17fc9", "#8d6c2f", "#d3277a", "#2ca1ae", "#9685eb", "#8a96c6",
        "#dba2e6", "#76fc1b", "#608fa4", "#20f6ba", "#07d7f6", "#dce77a", "#77ecca"
    ];

    let element = $(selector);

    let sessionKey = 'xyzpdq'; // TODO: implement user authentication

    const graph = this;

    // For the graph viewer: if the Popups manager doesn't exist, then create stubs that do nothing.
    let Popups = ('Popups' in window) ? window.Popups :  {
        syncOpen: function () {
        }, syncClose: function () {
        }, info: function () {
        }
    };

    // ------ public methods ------

    /**
     * Add a new dataset with the given name to the chart
     * @param key {string} The dataset key to load data
     * @param name {string} The dataset name to load and add to the graph
     * @param onAdded {function} [optional] Function to call on load success: callback(series)
     * @param unit {string} [optional] Unit of the series
     * @param unitDisplayName {string} [optional] The text to show of unit
     * @param color {string} [optional] Color for the series (omit for default)
     */
    this.addDataset = function(key, name, onAdded, unit, unitDisplayName, color) {
        if (yAxisRefreshTimer) {
            setTimeout(() => {this.addDataset(name, onAdded, unit, color)}, 500);
            return;
        }

        let series = chart ? chart.get(name) : null;
        color = color || colors[Math.floor(Math.random() * colors.length)];

        if (!series) {
            let placeholder = {name, data: [], id: key, type: chartType, unit, unitDisplayName, zIndex: 2};

            placeholder.color = color;

            if (chart) {
                if (!chart.yAxis.length || !chart.yAxis[0].axisTitle || unitDisplayName != chart.yAxis[0].axisTitle.textStr) {
                    let axisIndex = -1;

                    chart.yAxis.forEach((axis, i) => {
                        if (axis.axisTitle && unitDisplayName == axis.axisTitle.textStr) axisIndex = i;
                    });

                    if (axisIndex < 0) {
                        let labels   = {align: 'right', x: -2, y: 5};
                        let opposite = false;

                        if (chart.yAxis.length & 1) {
                            labels   = {align: 'left', x: 2, y: 5};
                            opposite = true;
                        }

                        chart.addAxis({title: {text: unitDisplayName, style: {color}}, labels, opposite});
                        axisIndex = chart.yAxis.length - 1;
                    }

                    placeholder.type   = 'spline';
                    placeholder.yAxis  = axisIndex;
                    placeholder.zIndex = 2;

                    if (axisIndex == 1) {
                        placeholder.type = 'column';
                        placeholder.zIndex = 1;
                    } else if (axisIndex == 2) {
                        placeholder.marker = {enabled: false};
                        placeholder.dashStyle = 'shortdot';
                    } else if (axisIndex == 3) {
                        placeholder.type      = 'line';
                        placeholder.dashStyle = 'dash';
                    } else if (axisIndex == 4) {
                        placeholder.marker = {enabled: false};
                        placeholder.dashStyle = 'dashdot';
                    }
                }

                series = chart.addSeries(placeholder);
            } else {
                chart = setup(placeholder);
                series = chart.get(key);
            }
        }

        this.modified = true;
        // Load it from the server
        loadDataset(series, onAdded);
    };

    /**
     * Remove the given dataset from the chart
     */
    this.removeDataset = function (name) {
        let series = chart ? chart.get(name) : null;
        series && series.remove();
        this.modified = true;

        //dataToQuery() //send updated data to query
    };

    let yAxisRefreshTimer;

    this.refreshYAxes = () => new Promise(resolve => {
        if (chart) {
            if (yAxisRefreshTimer) {
                clearTimeout(yAxisRefreshTimer);
            }

            yAxisRefreshTimer = setTimeout(() => {
                for (let axis of chart.yAxis) {
                    if (!axis.series.length) axis.remove();
                }

                yAxisRefreshTimer = null;
                resolve();
            }, 100);
        } else resolve();
    });

    /**
     * Remove all datasets from the graph
     */
    this.clear = async function () {
        if (!chart) return;

        while (Object.keys(chart.series).length) {
            for (let series of chart.series) {
                series.remove();
            }
        }

        await this.refreshYAxes();

        this.modified = true;
    };

    /**
     * Return the color used to render a series.
     * @return {string} The color string or could be null if the series is invalid.
     */
    this.getColor = function (name) {
        let series = chart ? chart.get(name) : null;
        return series ? series.color : null;
    };

    /**
     * Set the type of chart to display
     * @param type {string} 'column', 'line', or 'spline'
     */
    this.setType = function (type) {
        if (type == chartType) return;

        this.modified = !!chart;
        chartType = type;

        if (!chart) return;

        for (let series of chart.series) {
            series.update({type});
        }

        setTimeout(() => {
            $('#graph-time #start').trigger('slidestop');
        }, 500);
    };

    /**
     * Return the chart type
     */
    this.getType = function () {
        return chartType;
    };

    /**
     * Sets the new time range for the data and reloads new data from the server
     */
    this.setTimeRange = function (time_low, time_high, force = false) {
        time_high = time_high || 1;

        if (!force) {
            clearTimeout(this.timeRangeTimeout);

            this.timeRangeTimeout = setTimeout(() => {
                this.setTimeRange(time_low, time_high, true);
            }, 500);

            return;
        }

        if (typeof chart != typeof undefined) {
            this.loadingFadeOutIn += chart.series.length - 1;
        }

        this.time_start = parseFloat(time_low)  || 0;
        this.time_end   = parseFloat(time_high) || 0;

        if (chart) {
            chart.xAxis[0].setExtremes(time_low, chartType != 'column' ? time_high : time_low, chartType != 'column');
        } else {
            $("#loader2").fadeOut();
        }
    };

    /**
     * Show or hide the title (name) of the graph
     */
    this.showTitle = function (show, redraw) {
        if (!chart) return;

        redraw = (redraw === undefined) ? true : redraw;
        chart.setTitle({text: this.name}, null, redraw);
    };

    /**
     * Load the graph from the server using the unique ID
     * @param id {string} graph unique ID
     * @param onComplete {Function} [optional] call when finished with arguments: success {Boolean}
     */
    this.extendedOptions = {
        chart: {
            style: {
                fontFamily: 'Abel',
            },
            backgroundColor: null,
            spacingBottom: 20,
            spacingTop: 10,
            spacingLeft: 0,
            spacingRight: 10,
            marginBottom: 110,
            marginTop: 50,
            marginLeft: 65,
            marginRight: 30,
            events: {
                load(e) {
                    e.target.reflow();
                }
            }
        },
        tooltip: {
            formatter() {
                let text = 'Day: <b>'+(Number.isInteger(this.x) ? this.x : this.x.toFixed(2))+'</b><br>';

                this.points.forEach((point, i) => {
                    let val   = Number.isInteger(point.y) ? point.y : point.y.toFixed(2);
                    // let units = chart.series[i].yAxis.axisTitle.textStr.toLowerCase();
                    text += `<span style="color:${point.series.color}">●</span>${point.series.name}: <b></br>${val}</b><br>`;// ${units}<br>`;
                });

                return text;
            },
            shared: true
        },
        title: {
            style: {
                color: '#434348',
                fontSize: '25px'
            },
        },
        legend: {
            itemHiddenStyle: '#ababab',
            itemStyle: {
                fontSize: 15
            }
        },
        yAxis: {
            gridLineColor: '#d8d8d8',
            labels: {
                useHTML: true,
                formatter: function() { return this.value || '<b style="color:#000;">0</b>' },
                style: {
                    fontSize: '14px',
                    color: '#434348'
                }
            },
            lineColor: '#d8d8d8',
            minorGridLineColor: '#d8d8d8',
            tickColor: '#d8d8d8',
            minRange: 1
        },
        xAxis: {
            gridLineColor: '#d8d8d8',
            labels: {
                useHTML: true,
                formatter: function() { return this.value || '<b style="color:#000;">0</b>' },
                style: {
                    fontSize: '14px',
                    color: '#434348'
                }
            },
            lineColor: '#d8d8d8',
            minorGridLineColor: '#d8d8d8',
            tickColor: '#d8d8d8',
            title: {
                offset: 25,
                style: {
                    color: '#434348',
                    fontSize: '15px'
                }
            },
        },
        navigation: {
            buttonOptions: {
                symbolStroke: '#434348',
                theme: {
                    fill: '#75B25E'
                }
            },
            menuStyle: {
                border: '1px solid #477D32',
                background: '#E4EDE1'
            }
        }
    };

    this.load = function (category, timeMin, timeMax, onComplete) {
        Popups.syncOpen("Loading Graph...");

        Popups.syncOpen("Loading Graph...");
        graph.clear(); // reset the old graph
        graph.time_start = parseFloat(timeMin);
        graph.time_end   = parseFloat(timeMax);

        for (let cat of category) {
            graph.addDataset(cat.Value, cat.DisplayName, null, cat.Unit, cat.UnitDisplayName);
        }

        Popups.info("Graph loaded successfully", 'good', 2);
        onComplete && onComplete(true);
        Popups.syncClose();
    };


    /**
     * Save the graph to the server using the unique ID (or get one assigned)
     * @param {Function} onSaveComplete Called when save completes (not called if save() returns FALSE)
     * @return {boolean} TRUE on success and FALSE if there's nothing to save.
     */
    this.save = function (onSaveComplete) {
        if (chart == null || chart.series.length == 0)
            return false;

        Popups.syncOpen("Saving Graph...");

        // let vars = [], colors = [];
        for (let i in chart.series) {
            vars.push(chart.series[i].name);
            colors.push(chart.series[i].color);
        }

        let args = {
            'op': 'graph-save',
            'title': graph.name,
            'type': chartType,
            'variables': vars.join(','),
            'colors': colors.join(','),
            'time_start': graph.time_start,
            'time_end': graph.time_end,
            'session': sessionKey
        };

        if (this.id)
            args.id = this.id;

        $.ajax({
            url: "../ajax.php",
            data: args,
            success: function (data, status, xhr) {
                if ('id' in data) {
                    graph.id = data.id; // assign a unique ID
                    graph.modified = false;
                    Popups.info("Graph Saved Successfully!", 'good');
                }
            },
            error: function () {
                Popups.info("Failed to save graph! Check your network connection.", 'bad');
            },
            complete: function () {
                Popups.syncClose();
                onSaveComplete && onSaveComplete();
            }
        });

        return true;
    };


    /**
     * Pass graph variables to iframe's parent.
     */
    this.dataToQuery = function () {
        let vars = [], colors = [];

        for (let i in chart.series) {
            vars.push(chart.series[i].name);
            //colors.push( chart.series[i].color );
        }

        let args;

        if ($('.ui-block-c a').hasClass('ui-btn-active')) {

            /* if bar graph is selected */

            args = {
                'variables': vars.join(','),
                'single_time': graph.time_start,
            };

        } else {
            args = {
                'variables': vars.join(','),
                //'colors': colors.join(','),
                'time_start': graph.time_start,
                'time_end': graph.time_end,
            };
        }


        /* appending a graph value when a user edits a graph */

        /* getting a current value if it exists */

        let value = $('#law-add-graph #graph-data', parent.document.body).val();
        let current = value ? JSON.parse(value) : null;

        if (current != null) {
            current = JSON.parse($('#law-add-graph #graph-data', parent.document.body).val());
            let x = args.variables.split(',');

            current = current.variables;

            /* adding a graph data to $('#graph-data') if it isn't already there */

            if (typeof current == "string" && $.inArray(current, x) == -1) {

                /* if user adds first graph we're including its data to $('#graph-data') */
                x.push(current);

            } else if (typeof current == "object") {

                /* if user adds more graphs we're including array data to $('#graph-data') */

                for (let i = 0; i < current.length; i++) {
                    if ($.inArray(current[i], x) == -1) {
                        x.push(current[i]);
                    }
                }
            }

            /* including final data */
            args.variables = x;

            $('#law-add-graph #graph-data', parent.document.body).val(JSON.stringify(args));
        }

        $('#law-add-graph #graph-data', parent.document.body).val(JSON.stringify(args));
        // $("#law-add-graph", parent.document.body).empty().append("<input type='hidden' id='graph-data' value = '" + JSON.stringify(args) + "''>");
    };

    // ------------ private methods -------------

    /**
     * Setup initial chart options and create the chart
     */
    function setup(series) {
        let options = {
            title: {text: ''},
            chart: {type: chartType, renderTo: element[0], marginBottom: 80},
            colors,
            plotOptions: {
                spline: {marker: {enabled: false}},
                line:   {marker: {enabled: false}},
                column: {borderWidth: 0, pointPadding: 0, groupPadding: 0.05},
                series: {}
            },
            series:  [series],
            yAxis:   {title: {text: series.unitDisplayName, style: {color: series.color}}, labels: {align: 'right', x: -2, y: 5}},
            xAxis:   {
                min: graph.time_start, max: graph.time_end,
                title: {text: "Days", align: "high"},
                crosshair: true
            },
            credits: {enabled: false}
        };

        options = $.extend(true, options, graph.extendedOptions);

        return new Highcharts.Chart(options);
    }

    function getUnitIndex(unit)
    {
        for (let i = 0; i < chart.yAxis.length; i++)
        {
            if (chart.yAxis[i].axisTitle && unit == chart.yAxis[i].axisTitle.textStr)
                return i;
        }
        return -1;
    }
    let lastStartTime, lastEndTime;
    let datasetCache  = {};

    /**
     * Load the data from the server for the given series
     *
     * @param series Highcharts series instance.
     * @param onLoaded Callback for when the data has loaded (called on success only)
     * @param redraw
     */
    function loadDataset(series, onLoaded, redraw) {
        const loadCallback = (data) => {

            let labels   = {align: 'right', x: -2, y: 5};
            let opposite = true;

            if (chart.yAxis.length & 1) {
                labels   = {align: 'left', x: 2, y: 5};
                opposite = false;
            }
            if (getUnitIndex(data.Unit) == -1) chart.addAxis({title: {text: data.UnitDisplayName}, labels, opposite});

            let isLinesData = Object.keys(data).length > 0;

            if (isLinesData) {
                let resultData = [];

                for (let i = 0; i < data.Times.length; i++) {
                    resultData[i] = [data.Times[i] / (3600 * 24), data.Values[i]];
                }

                data = resultData;
            }

            let options = {data, lineWidth: 4};

            if (data instanceof Array && data.length > 0) {
                options.pointStart    = graph.time_start;
                options.pointInterval = (graph.time_end - graph.time_start) / data.length;
                graphicStep = options.pointInterval;
            }

            series.update(options, redraw);

            onLoaded && onLoaded(series);

            if (graph.loadingFadeOutIn > 0) {
                graph.loadingFadeOutIn--;
            } else {
                $("#loader2").fadeOut();
                graph.loadingFadeOutIn = 0;
            }
        };

        // load from cache
        if (graph.time_start === lastStartTime && graph.time_end === lastEndTime) {
            let cachedXhr = datasetCache[series.name];

            if (cachedXhr) {
                cachedXhr.done(loadCallback);
                return;
            }
        } else {
            // if date range was change then reset data set cache
            lastStartTime = graph.time_start;
            lastEndTime   = graph.time_end;
            datasetCache  = {};
        }

        redraw = (redraw === undefined) ? true : redraw;

        let seriesJson = series.userOptions.id;
        let pairs = seriesJson.split('/');
        seriesJson = pairs[pairs.length - 1].replace(/\s/g,'');

        let data = {
            dataSet:  seriesJson,
            dayStart: graph.time_start,
            dayEnd:   graph.time_end
        };

        if (data.dayStart == data.dayEnd) {
            data.dayEnd += 0.01;
        }

        let xhrCall = $.get('/datasets/get', data);

        datasetCache[series.name] = xhrCall;
        xhrCall.done(loadCallback);
        xhrCall.fail(function () {
            // remove cached request on failure
            delete datasetCache[series.name];
        });
    }
};