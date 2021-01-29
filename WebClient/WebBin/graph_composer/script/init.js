(function () {
    "use strict";
    let urlGameServer = APPIQUERYURL;
    // TODO: grab this via wiki login system (parameter to the iframe)
    let sessionKey = 'dfhyudifjkdshfklsdgoiysdoihgdsfhdlkf';

    /** @type {DatasetGraph} The dataset graph class */
    let graph;
    /** @type {Object} list of available saved graphs */
    let graphList = {};

    let reload = false;
    let savedGraphs = false;

    function timeBar() {
        let selector = $(".ui-slider-handle[aria-labelledby=end-label], .graph-range-day-right, .ui-slider-input#end");
        let start, end;

        $(".ui-slider-handle[aria-labelledby=start-label]").change();

        selector.show();

        start = graph.time_start;
        end = graph.time_end;
        $('#graph-time #start').attr({'min': start, 'max': end});
        $('#graph-time #end').slider('enable').attr({'min': start, 'max': end});

        $(".ui-slider-track").css("background-color", "transparent");

        graph.setTimeRange(start, end);
        graph.dataToQuery();

        reload = true;
    }

    function updateGraphData() {
        let currentGraphs = $('#law-add-graph #graph-data', parent.document.body).val();

        if (currentGraphs && currentGraphs.length) {
            currentGraphs = JSON.parse(currentGraphs);

            let min = $('[data-type=range]#start').attr('min');
            let max = $('[data-type=range]#end').attr('max');

            currentGraphs.time_start = parseFloat(min);
            currentGraphs.time_end   = parseFloat(max);

            $('#law-add-graph #graph-data', parent.document.body).val(JSON.stringify(currentGraphs));
        }
    }

    function sub_item(elm, ev) {
        elm.bind("click", function (e) {
            $("#loader2").fadeIn();
            e.stopPropagation();
            ev.stopPropagation();

            let step = graph.getGraphicStep();
            graph.clear();

            let data     = $(this).data("graph");
            let time_min = (Math.floor(data.TimeMin * 100) / 100).toFixed(step < 0.1 ? 2 : 1);
            let time_max = (Math.floor(data.TimeMax * 100) / 100).toFixed(step < 0.1 ? 2 : 1);
            let graphs   = data.Keys;

            graph.setTimeRange(time_min, time_max);
            graphs.forEach((element) => {
                graph.addDataset(element.join('/'));
                graph.dataToQuery();
            });

            //setting the graph type
            if (time_min == time_max) {
                $(".ui-rangeslider-sliders .ui-slider-bg").css({'width': '100%', 'margin-left': '0', 'display': 'block'});
                $(".ui-block-c a").click();
            } else {
                $(".ui-block-a a").click();
            }

            $('#load-saved-graphs').attr("data-start", time_min).attr("data-end", time_max);
            updateTimeRange([time_min, time_max]);
        })
    }

    function onClickGraphSave() {
        let name = $('input#graph-name').val();

        if (name.length < 2) {
            Popups.info("Enter a valid title before saving. Your graph must have a unique title.");
            return false;
        }

        graph.name = name;

        for (let key in graphList) {
            if (key != graph.id && graphList[key].toUpperCase() == name.toUpperCase()) {
                Popups.info("<span class='localize' translate-key='121'>A graph with that title already exists! Choose a unique title for your graph.</span>");
                return false;
            }
        }

        if (!graph.save(updateGraphList)) {
            // can't save
            Popups.info("<span class='localize' translate-key='122'>Please add a dataset to your graph before saving.</span>");
            return false;
        }

        return true;
    }

    function onClickGraphCopy() {
        promptToSaveChanges(function() {
            graph.id       = null;
            graph.modified = false;

            $('#graph-name').val("Copy of " + $('#graph-name').val());
            Popups.info("<span class='localize' translate-key='123'>Graph copied. Type a unique name and save it.</span>", "good");
        });
    }

    function onClickGraphNew() {
        promptToSaveChanges(function() {
            graph.id = null;
            graph.clear();
            graph.modified = false;

            $("#graph-name").val('');
            updateSelectedDatasets();
        });
    }

    function promptToSaveChanges(onProceed) {
        if (graph.modified) {
            let fields = {
                header:  "Graph Modified",
                subtext: $("#graph-name").val(),
                body:    "<span class='localize' translate-key='124'>Do you want to save your changes before proceeding?</span>",
                btn0:    "<span class='localize' translate-key='125'>Don't Save</span>",
                btn1:    "<span class='localize' translate-key='18'>Save</span>"
            };

            Popups.prompt(fields, function (btn) {
                if (btn == "btn1" && !onClickGraphSave()) return; // save failed
                onProceed();
            });
        } else onProceed();
    }

    function activateTimeBar(type) {
        if (getURLParameter("frontpage") == null && graph.modified) {
            let range = {min: graph.time_start, max: graph.time_end, step: graph.getGraphicStep()};
            $('#graph-time #start').attr(range).slider("enable");
            $('#graph-time #end').attr(range).slider("enable");
        }
    }

    function updateTimeRange(timeData) {
        timeData = timeData || false;

        if (getURLParameter('page') == 'dashboard') return false;

        window.parent.$('#page').addClass('hide-graph');

        $.ajax({
            url: urlGameServer+"/datasets/timerange",
            data: {},
            success: function(data, status, xhr) {
                if (timeData) updateTimeRangeByData(timeData);
                else updateTimeRangeByData(data);
            },
            complete: function() {
                if (graph.time_start == graph.time_end) {
                    $(".ui-rangeslider-sliders .ui-slider-bg").css({'width': '100%', 'margin-left': '0', 'display': 'block'});
                }

                window.parent.$('#page').removeClass('hide-graph');

                if (reload) {
                    $(".ui-slider-handle:first").css('left', '0');
                    $(".ui-slider-handle:last").css('left', '100%');

                    $(".ui-rangeslider-sliders .ui-slider-bg").each(function() {
                        $(this).css({'width': '100%', 'margin-left': '0', 'display': 'block'});
                    });

                    let start = (graph.time_start == 0) ? 0 : parseFloat(graph.time_start).toFixed(1);
                    let end   = (graph.time_end == 0)   ? 0 : parseFloat(graph.time_end).toFixed(graph.time_end >= 1 ? 1 : 2);

                    $('#graph-time #start').val(start);
                    $('#graph-time #end').val(end);

                    graph.time_start = start;
                    graph.time_end = end;
                    reload = false;
                }
            }
        });

        function updateTimeRangeByData(data) {
            activateTimeBar(graph.time_start == graph.time_end ? "bar" : "spline");

            let range = {min: data[0], max: data[1], step: (data[1] > 1) ? 0.1 : 0.01};

            if (data[1] > 1) {
                range.max = (Math.floor(range.max * 10) / 10).toFixed(1);
            } else {
                range.max = (Math.floor(range.max * 100) / 100).toFixed(2);
            }

            graph.setTimeRange(range.min, range.max);
            $('#graph-time #start').attr(range).slider('refresh');
            $('#graph-time #end').attr(range).slider('refresh');
        }
    }

    function renderDatasetList(data, category) {
        let attrCategory = {
            'data-role':           'collapsible',
            'data-iconpos':        'left',
            'data-shadow':         'false',
            'data-corners':        'false',
            'data-collapsed-icon': 'carat-r',
            'data-expanded-icon':  'carat-d',
            'data-mini':           'false',
            'data-collapsed':      'true',
            'data-inset':          'false'
        };

        let list = $('<ul></ul>').attr({
            'class':        'ui-listview',
            'data-role':    'listview',
            'data-shadow':  'false',
            'data-inset':   'false',
            'data-corners': 'false',
            'style':        'margin-right:0'
        });

        data = Object.values(data);
        data.sort((a, b) => a.name > b.name ? 1 : -1);

        for (let n in data) {
              if (data[n].children) {
                  let $cat = $(`<div><h2> ${data[n].title}<span class="count nested"></span></h2></div>`).attr(attrCategory);
                  let ul   = renderDatasetList(data[n].children, category + "/" + n);

                  $cat.append(ul);
                  list.append($cat);
            }
        }

        if (!data[Object.keys(data).pop()].children) {
            for (let item of data) {
                let $a = $(`<a class="miniListItem ui-icon-plus ui-btn ui-btn-icon-right" title="${item.descr}" href="#">${item.title}</a>`);

                $a.attr({
                    'data-name':   item.name,
                    'data-unit':   item.unit,
                    'data-unitDisplayName':   item.unitDisplayName,
                    'data-parent': category,
                });

                $a.wrap('<li data-icon="plus"></li>');
                list.append($a.parent());
            }
        }

        return list;
    }

    function updateDatasetList() {
        $.get(urlGameServer+"/datasets/treelist", {session: sessionKey}, data => {
            let container    = $('#data-list');
            let attrCategory = {
                'data-role':           'collapsible',
                'data-iconpos':        'left',
                'data-shadow':         'false',
                'data-corners':        'false',
                'data-collapsed-icon': 'carat-r',
                'data-expanded-icon':  'carat-d',
                'data-mini':           'false',
                'data-collapsed':      'true',
                'data-inset':          'false'
            };

            for (let item of data.ChildrenCategories) {
                let sets = [];
                let cat  = $(`<div><h2 data-name="${item.Name}">${item.DisplayName}<span class="count"></span></h2></div>`).attr(attrCategory);

                container.append(cat);

                fillSetsWithData(item.ChildrenCategories.length ? item.ChildrenCategories : item.ChildrenStats, sets);

                let list = renderDatasetList(sets, item.DisplayName);
                cat.append(list);

                list.listview().listview("refresh");
                $('li > a', list).click(onClickDataset);
            }

            container.collapsibleset().collapsibleset("refresh");
            $('.ui-collapsible h2 a', container).addClass('ui-nodisc-icon ui-alt-icon');

            $('[data-role=collapsible]').collapsible({
                collapse: function() {
                    $(this).children().next().slideUp();
                },
                expand: function() {
                    $(this).children().next().hide().slideDown();
                }
            });

            updateGroupCount($('.ui-collapsible', container));
        });
    }

    function fillSetsWithData(data, sets) {
        if (!sets) return;

        for (let item of data) {
            let i = sets.push({
                name : item.Name,
                title: item.DisplayName,
                descr: item.Description,
                unit:  item.Unit,
                unitDisplayName:  item.UnitDisplayName,
            }) - 1;

            if (item.ChildrenCategories && (item.ChildrenCategories.length || item.ChildrenStats.length)) {
                sets[i].children = [];
                fillSetsWithData(item.ChildrenCategories.length ? item.ChildrenCategories : item.ChildrenStats, sets[i].children);
            }
        }
    }

    async function onClickDataset() {
        let menu  = $(this);
        let group = menu.parents('div.ui-collapsible');
        let name  = menu.data().name;
        let displayName = menu.text();

        if (menu.hasClass("ui-icon-plus")) {
            await graph.refreshYAxes();
            graph.addDataset(name, displayName, function(series) {
                menu.css({color: series.color});
                menu.removeClass("ui-icon-plus").addClass("ui-icon-minus");
                updateGroupCount(group);
            },  menu.data('unit'), menu.data('unitdisplayname'));
        } else {
            graph.removeDataset(name);
            menu.css({color: ''});
            menu.removeClass("ui-icon-minus").addClass("ui-icon-plus");
            updateGroupCount(group);
        }

        graph.dataToQuery(); //Update hidden input on index with user's graph selection - live
        updateTimeRange();
    }

    function updateSelectedDatasets() {
        // Go through the datasets and select
        $('#data-list li > a').each(function() {
            let menu  = $(this);
            let color = graph.getColor(menu.data('name'));

            if (color) {
                menu.css({color: color});
                menu.removeClass("ui-icon-plus").addClass("ui-icon-minus");
            } else {
                menu.css({color: ''});
                menu.removeClass("ui-icon-minus").addClass("ui-icon-plus");
            }
        });

        updateGroupCount($("#panel-datasets .ui-collapsible"));
    }

    function updateGroupCount(groups) {
        groups.each(function() {
            let count = $(this).find('.ui-icon-minus').length;
            $(this).find('h2 span.count:eq(0)').text(count ? "("+count+")" : "");
        });
    }

    function updateGraphList() {
        // making available edit graph functionality
        setTimeout(function() {
            /* show graph name on the input */
            $('#graph-name').val(graph.name);

            let currentGraphs = $('#law-add-graph #graph-data', parent.document.body).val();
            let time_start, time_end;

            if (typeof currentGraphs == "string" && currentGraphs) {
                time_start = (JSON.parse(currentGraphs)).time_start;
                time_end = (JSON.parse(currentGraphs)).time_end;
                graph.setTimeRange(time_start, time_end);
                /* including already made graphs to the new ones*/

                currentGraphs = JSON.parse(currentGraphs);
                currentGraphs = currentGraphs.categories || currentGraphs.Categories;

                /* the case when user have added one graph */
                if (typeof currentGraphs == "string") {
                    graph.addDataset(currentGraphs);
                    /* the case when user have added more than one graphs */
                } else if (typeof currentGraphs == "object") {
                    if (currentGraphs.length == 1) {
                        graph.addDataset(currentGraphs);
                    } else {
                        for (let i = 0; i < currentGraphs.length; i++) {
                            graph.addDataset(currentGraphs[i]);

                            /* loading categories */
                            loadGraphCategory(currentGraphs[i].split('/')[0], currentGraphs[i].split('/')[1]);
                        }
                    }
                }
            }

            let range = {min: parseFloat(time_start), max: parseFloat(time_end), step: graph.getGraphicStep()};

            $('#graph-time #start').attr(range).slider('refresh');
            $('#graph-time #end').attr(range).slider('refresh');
        }, 1000);
    }

    function loadGraphCategory(parent, child) {
        /* finding saved graphs and loading them under data column */
        $('#data-list li > a').each(function() {
            if ($(this).data('parent') == parent && $(this).html() == child) {
                $(this).click();
            }
        });
    }

    function unselectCategories() {
        $('#data-list li > a.ui-icon-minus').click();
    }

    function onClickGraphOpen() {
        $('#panel-graphs').panel("close");

        promptToSaveChanges(function() {
            graph.extendedOptions = {
                chart: {
                    style: {
                        fontFamily: 'Abel'
                    },
                    backgroundColor: null,
                    spacingBottom: 20,
                    spacingTop: 10,
                    spacingLeft: 0,
                    spacingRight: 10,
                    marginBottom: 110,
                    marginTop: 25,
                    marginLeft: 65,
                    marginRight: 30
                },
                title: {
                    style: {
                        color: '#434348',
                        fontSize: '25px'
                    }
                },
                legend: {
                    itemHiddenStyle: '#d8d8d8',
                    itemStyle: {
                        fontSize: 15
                    }
                },
                yAxis: {
                    gridLineColor: '#d8d8d8',
                    labels: {
                        style: {
                            fontSize: '15px',
                            color: '#434348'
                        }
                    },
                    lineColor: '#d8d8d8',
                    minorGridLineColor: '#d8d8d8',
                    tickColor: '#d8d8d8'
                },
                xAxis: {
                    gridLineColor: '#d8d8d8',
                    labels: {
                        style: {
                            fontSize: '15px',
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
                            fontSize: '17px'
                        }
                    }
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
                        background: '#000000'
                    }
                }
            };

            graph.load($(this).parent().attr('id'), success => {
                if (!success) return;

                // Update the GUI to match graph properties
                $("#graph-name").val(graph.name);
                $("#graph-type a").removeClass('ui-btn-active').filter("#" + graph.getType()).addClass('ui-btn-active'); // select active type
                $('#graph-time #start').val(graph.time_start).slider('refresh');
                $('#graph-time #end').val(graph.time_end).slider('refresh');

                updateSelectedDatasets();
            });
        });
    }

    function onClickGraphDelete() {
        let idGraph = $(this).parent().attr('id');

        let fields = {
            header: 'Delete Graph?',
            body: 'Are you sure you want to remove this graph?',
            subtext: 'This action cannot be undone.',
            btn0: 'Cancel',
            btn1: 'Delete'
        };

        Popups.prompt(fields, function(btn) {
            if (btn == 'btn1') {
                let panel = $('#panel-graphs').addClass('ui-loading');
                $('ul#list', panel).html("");
                // call ajax function to remove the graph
                $.ajax({
                    url: "../ajax.php",
                    data: {op: "graph-delete", id: idGraph, session: sessionKey},
                    complete: updateGraphList
                });
            }
        });
    }

    function getURLParameter(name) {
        return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null;
    }

    $(document).on("pagebeforeshow", '#graph_composer', function(event) {
        $.ajax({
            url: urlGameServer + "/datasets/timerange",
            success: function (data, status, xhr) {
                if (data[1] < 0.01) {
                    $('.ui-grid-c>.ui-block-a').css({'display': 'none'});
                    $('.ui-grid-c>.ui-block-c').css({'width': '100%'});
                }
            }
        });

        if (getURLParameter('page') != 'dashboard') {
            if (typeof graph == "undefined") {
                $('#graph-time #end').slider('disable');
                $('#graph-time #start').slider('disable');
            }

            updateDatasetList();
            updateGraphList();
        }
    });

    $(document).on("keypress", "#start, #end", function() {
        if ($(this).val() === "") $(this).val(0);
        $(this).trigger("slidestop");
    });

    $(document).on("change", "#graph-time #start", () => {
        $('#graph-time #start').off('mousemove').mousemove(function(e) {
            if (e.clientX < 50) {
                $(this).mouseup();
            }
        });
    });

    $(document).on("change", "#graph-time #end", () => {
        $('#graph-time #end').off('mousemove').mousemove(function(e) {
            if (e.clientX < 50) {
                $(this).mouseup();
            }
        });
    });

    $(document).on("click", ".unselect-categories", () => {
        $('#graph-categories > li').removeClass("opened");
        $('#graph-categories').empty();
        graph.clear();
        unselectCategories();
        $("#saved-graphs").slideUp();
        $('#load-saved-graphs').removeClass("opened");
        $('#load-saved-graphs > a').removeClass("ui-icon-carat-d").addClass("ui-icon-carat-r");
        savedGraphs = false;
        timeBar(true);
    });

    $(document).on("click", ".goFullWidth", function() {
        // Simplified selector
        let $col = window.parent.$('#graphContainer');

        if ($(this).text() == '←→') {
            $col.prev().hide();
            $col.removeClass('col-lg-8').addClass('col-lg-12');
            $col.removeClass('col-xl-8').addClass('col-xl-12');
            $(this).text('→←');
        } else {
            // Show map only if was visible before
            if (!window.parent.$('.add-map-button').is(':visible')) {
                $col.prev().show();
            }

            $col.removeClass('col-lg-12').addClass('col-lg-8');
            $col.removeClass('col-xl-12').addClass('col-xl-8');
            $(this).text('←→');
        }
    });

    $(document).on("click", '#load-saved-graphs > a', function() {
        if ($("#saved-graphs").css("display") == "block") {
            $('#load-saved-graphs > a').removeClass("ui-icon-carat-d").addClass("ui-icon-carat-r");
            $("#saved-graphs").slideUp();
            return;
        }

        $(".subcategories").slideUp();
        savedGraphs = true;

        if (!$(this).hasClass("opened")) {
            unselectCategories();
        }

        $(this).addClass("opened");

        let container = $('#load-saved-graphs');
        $('#graph-categories').empty();

        //getting the graph data
        $.get('/data/FrontPageGraphs.json', data => {
            $('#load-saved-graphs > #saved-graphs').empty();

            //createing the category list
            let $ul = $('<ul style="list-style-type:none;text-align:left; float:right;" id="graph-categories"></ul>');

            //adding the category items to the list
            for (let cat in data.categories) {
                let classes = 'ui-icon-plus ui-btn ui-btn-icon-right';
                let keys    = data.categories[cat].map(key => key.replace(/\s/g, '')).join(',');

                $ul.append(`<li><a style="margin:0" title="${cat}" class="${classes}" data-keys="${keys}">${cat}</a></li>`);
            }

            container.find("#saved-graphs").append($ul).slideToggle(() => {
                let elm = $('#load-saved-graphs > a');

                if (elm.hasClass("ui-icon-carat-r")) {
                    elm.removeClass("ui-icon-carat-r");
                    elm.addClass("ui-icon-carat-d");
                } else {
                    elm.removeClass("ui-icon-carat-d");
                    elm.addClass("ui-icon-carat-r");

                    $('#graph-categories > li').each(function() {
                        $(this).slideUp();
                    })
                }
            });

            //loading the second layer of categoires
            $("#graph-categories a").click(function(e) {
                e.preventDefault();
                unselectCategories();

                let $dataList = $('#data-list');
                graph.clear();

                // Adding time gap for HighCharts to clear everything (it's not synchronous process seems, but also has no callback)
                setTimeout(() => {
                    // Create a work around for HighCharts where we click trigger a click on each key every 250ms, because otherwise HighCharts bug and add only last clicked series.
                    e.currentTarget.dataset.keys.split(',').forEach((key, i) => {
                        setTimeout(() => {
                            $dataList.find(`a.miniListItem[data-name="${key}"]`).click();
                        }, i * 250);
                    });
                }, 500);
            })
        });
    });

    $(document).on("pageshow", '#graph_composer', function(event) {
        $('#graph').css({'height': 340 + "px"});

        // Create the graph class
        graph = new DatasetGraph('#graph');

        // Handle save/copy/new buttons
        $('a#btn-save').click(onClickGraphSave);
        $('a#btn-copy').click(onClickGraphCopy);
        $('a#btn-new').click(onClickGraphNew);

        // Handle modification of graph name
        $('#graph-name').change(() => {
            graph.modified = true;
        });

        $('#graph-time #start').on("slidestart", () => {
            $(".ui-rangeslider-sliders .ui-slider-bg").each(function() {
                $(this).css({'width': '100%', 'margin-left': '0', 'display': 'block'});
            });
        }).on('slidestop', function() {
            if (graph.time_start == graph.time_end) {
                $(".ui-rangeslider-sliders .ui-slider-bg").css({'width': '100%', 'margin-left': '0', 'display': 'block'});
            }

            graph.setTimeRange(parseFloat($(this).val()), graph.time_end);
            graph.dataToQuery();
        });

        // Handle changing of the time rangeslider
        $('#graph-time #end').on('slidestop', function() {
            if (graph.time_start == graph.time_end) {
                $(".ui-rangeslider-sliders .ui-slider-bg").css({'width': '100%', 'margin-left': '0', 'display': 'block'});
            }

            graph.setTimeRange(graph.time_start, parseFloat($(this).val()));
            graph.dataToQuery();
        });

        $(".ui-slider-bg").on('mousedown', function() {
            $(this).off('mousemove').on('mousemove', function() {
                $(".ui-rangeslider-sliders .ui-slider-bg").css({'width': '100%', 'margin-left': '0', 'display': 'block'});
            });
        });

        if (graph.time_start == graph.time_end) {
            $(".ui-rangeslider-sliders .ui-slider-bg").css({'width': '100%', 'margin-left': '0', 'display': 'block'});
        }

        updateTimeRange();

        if (settings) {
            setTimeout(function () {
                let TimeMin = settings.TimeMin;
                let TimeMax = settings.TimeMax;

                for (let keys of settings.Keys) {
                    graph.addDataset(keys.join('/'));
                }

                graph.setTimeRange(TimeMin, TimeMax);

                let range = {min: TimeMin, max: TimeMax, step: graph.getGraphicStep()};

                $(".ui-block-a a").click();
                $("#graph-time #start").attr(range).val(range.min).slider("refresh");
                $("#graph-time #end").attr(range).val(range.max).slider("refresh");
            }, 1000);
        }
    })
})();


// Copied from MDN documentation for older browsers
if (!String.prototype.trim) {
    (function() {
        // Make sure we trim BOM and NBSP
        String.prototype.trim = function() {
            return this.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, "");
        }
    })();
}
