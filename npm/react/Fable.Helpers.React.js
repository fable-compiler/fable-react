import * as react from "react";
import { toPlainJsObj } from "fable-core/Util";
export var Props = function (__exports) {
    return __exports;
}({});
export function fn(f, props, children) {
    return react.createElement.apply(react, [f, toPlainJsObj(props)].concat(Array.from(children)));
}
export function com(props, children, _genArgs) {
    return react.createElement.apply(react, [_genArgs.T, toPlainJsObj(props)].concat(Array.from(children)));
}
export function from(com_1, props, children) {
    return react.createElement.apply(react, [com_1, toPlainJsObj(props)].concat(Array.from(children)));
}
export function domEl(tag, props, children) {
    return react.createElement.apply(react, [tag, props].concat(Array.from(children)));
}
export function svgEl(tag, props, children) {
    return react.createElement.apply(react, [tag, props].concat(Array.from(children)));
}
export function a(b, c) {
    return domEl("a", b, c);
}
export function abbr(b, c) {
    return domEl("abbr", b, c);
}
export function address(b, c) {
    return domEl("address", b, c);
}
export function area(b, c) {
    return domEl("area", b, c);
}
export function article(b, c) {
    return domEl("article", b, c);
}
export function aside(b, c) {
    return domEl("aside", b, c);
}
export function audio(b, c) {
    return domEl("audio", b, c);
}
export function b(b_, c) {
    return domEl("b", b_, c);
}
export function base(b_1, c) {
    return domEl("base", b_1, c);
}
export function bdi(b_1, c) {
    return domEl("bdi", b_1, c);
}
export function bdo(b_1, c) {
    return domEl("bdo", b_1, c);
}
export function big(b_1, c) {
    return domEl("big", b_1, c);
}
export function blockquote(b_1, c) {
    return domEl("blockquote", b_1, c);
}
export function body(b_1, c) {
    return domEl("body", b_1, c);
}
export function br(b_1, c) {
    return domEl("br", b_1, c);
}
export function button(b_1, c) {
    return domEl("button", b_1, c);
}
export function canvas(b_1, c) {
    return domEl("canvas", b_1, c);
}
export function caption(b_1, c) {
    return domEl("caption", b_1, c);
}
export function cite(b_1, c) {
    return domEl("cite", b_1, c);
}
export function code(b_1, c) {
    return domEl("code", b_1, c);
}
export function col(b_1, c) {
    return domEl("col", b_1, c);
}
export function colgroup(b_1, c) {
    return domEl("colgroup", b_1, c);
}
export function data(b_1, c) {
    return domEl("data", b_1, c);
}
export function datalist(b_1, c) {
    return domEl("datalist", b_1, c);
}
export function dd(b_1, c) {
    return domEl("dd", b_1, c);
}
export function del(b_1, c) {
    return domEl("del", b_1, c);
}
export function details(b_1, c) {
    return domEl("details", b_1, c);
}
export function dfn(b_1, c) {
    return domEl("dfn", b_1, c);
}
export function dialog(b_1, c) {
    return domEl("dialog", b_1, c);
}
export function div(b_1, c) {
    return domEl("div", b_1, c);
}
export function dl(b_1, c) {
    return domEl("dl", b_1, c);
}
export function dt(b_1, c) {
    return domEl("dt", b_1, c);
}
export function em(b_1, c) {
    return domEl("em", b_1, c);
}
export function embed(b_1, c) {
    return domEl("embed", b_1, c);
}
export function fieldset(b_1, c) {
    return domEl("fieldset", b_1, c);
}
export function figcaption(b_1, c) {
    return domEl("figcaption", b_1, c);
}
export function figure(b_1, c) {
    return domEl("figure", b_1, c);
}
export function footer(b_1, c) {
    return domEl("footer", b_1, c);
}
export function form(b_1, c) {
    return domEl("form", b_1, c);
}
export function h1(b_1, c) {
    return domEl("h1", b_1, c);
}
export function h2(b_1, c) {
    return domEl("h2", b_1, c);
}
export function h3(b_1, c) {
    return domEl("h3", b_1, c);
}
export function h4(b_1, c) {
    return domEl("h4", b_1, c);
}
export function h5(b_1, c) {
    return domEl("h5", b_1, c);
}
export function h6(b_1, c) {
    return domEl("h6", b_1, c);
}
export function head(b_1, c) {
    return domEl("head", b_1, c);
}
export function header(b_1, c) {
    return domEl("header", b_1, c);
}
export function hgroup(b_1, c) {
    return domEl("hgroup", b_1, c);
}
export function hr(b_1, c) {
    return domEl("hr", b_1, c);
}
export function html(b_1, c) {
    return domEl("html", b_1, c);
}
export function i(b_1, c) {
    return domEl("i", b_1, c);
}
export function iframe(b_1, c) {
    return domEl("iframe", b_1, c);
}
export function img(b_1, c) {
    return domEl("img", b_1, c);
}
export function input(b_1, c) {
    return domEl("input", b_1, c);
}
export function ins(b_1, c) {
    return domEl("ins", b_1, c);
}
export function kbd(b_1, c) {
    return domEl("kbd", b_1, c);
}
export function keygen(b_1, c) {
    return domEl("keygen", b_1, c);
}
export function label(b_1, c) {
    return domEl("label", b_1, c);
}
export function legend(b_1, c) {
    return domEl("legend", b_1, c);
}
export function li(b_1, c) {
    return domEl("li", b_1, c);
}
export function link(b_1, c) {
    return domEl("link", b_1, c);
}
export function main(b_1, c) {
    return domEl("main", b_1, c);
}
export function map(b_1, c) {
    return domEl("map", b_1, c);
}
export function mark(b_1, c) {
    return domEl("mark", b_1, c);
}
export function menu(b_1, c) {
    return domEl("menu", b_1, c);
}
export function menuitem(b_1, c) {
    return domEl("menuitem", b_1, c);
}
export function meta(b_1, c) {
    return domEl("meta", b_1, c);
}
export function meter(b_1, c) {
    return domEl("meter", b_1, c);
}
export function nav(b_1, c) {
    return domEl("nav", b_1, c);
}
export function noscript(b_1, c) {
    return domEl("noscript", b_1, c);
}
export function object(b_1, c) {
    return domEl("object", b_1, c);
}
export function ol(b_1, c) {
    return domEl("ol", b_1, c);
}
export function optgroup(b_1, c) {
    return domEl("optgroup", b_1, c);
}
export function option(b_1, c) {
    return domEl("option", b_1, c);
}
export function output(b_1, c) {
    return domEl("output", b_1, c);
}
export function p(b_1, c) {
    return domEl("p", b_1, c);
}
export function param(b_1, c) {
    return domEl("param", b_1, c);
}
export function picture(b_1, c) {
    return domEl("picture", b_1, c);
}
export function pre(b_1, c) {
    return domEl("pre", b_1, c);
}
export function progress(b_1, c) {
    return domEl("progress", b_1, c);
}
export function q(b_1, c) {
    return domEl("q", b_1, c);
}
export function rp(b_1, c) {
    return domEl("rp", b_1, c);
}
export function rt(b_1, c) {
    return domEl("rt", b_1, c);
}
export function ruby(b_1, c) {
    return domEl("ruby", b_1, c);
}
export function s(b_1, c) {
    return domEl("s", b_1, c);
}
export function samp(b_1, c) {
    return domEl("samp", b_1, c);
}
export function script(b_1, c) {
    return domEl("script", b_1, c);
}
export function section(b_1, c) {
    return domEl("section", b_1, c);
}
export function select(b_1, c) {
    return domEl("select", b_1, c);
}
export function small(b_1, c) {
    return domEl("small", b_1, c);
}
export function source(b_1, c) {
    return domEl("source", b_1, c);
}
export function span(b_1, c) {
    return domEl("span", b_1, c);
}
export function strong(b_1, c) {
    return domEl("strong", b_1, c);
}
export function style(b_1, c) {
    return domEl("style", b_1, c);
}
export function sub(b_1, c) {
    return domEl("sub", b_1, c);
}
export function summary(b_1, c) {
    return domEl("summary", b_1, c);
}
export function sup(b_1, c) {
    return domEl("sup", b_1, c);
}
export function table(b_1, c) {
    return domEl("table", b_1, c);
}
export function tbody(b_1, c) {
    return domEl("tbody", b_1, c);
}
export function td(b_1, c) {
    return domEl("td", b_1, c);
}
export function textarea(b_1, c) {
    return domEl("textarea", b_1, c);
}
export function tfoot(b_1, c) {
    return domEl("tfoot", b_1, c);
}
export function th(b_1, c) {
    return domEl("th", b_1, c);
}
export function thead(b_1, c) {
    return domEl("thead", b_1, c);
}
export function time(b_1, c) {
    return domEl("time", b_1, c);
}
export function title(b_1, c) {
    return domEl("title", b_1, c);
}
export function tr(b_1, c) {
    return domEl("tr", b_1, c);
}
export function track(b_1, c) {
    return domEl("track", b_1, c);
}
export function u(b_1, c) {
    return domEl("u", b_1, c);
}
export function ul(b_1, c) {
    return domEl("ul", b_1, c);
}

function _var(b_1, c) {
    return domEl("var", b_1, c);
}

export { _var as var };
export function video(b_1, c) {
    return domEl("video", b_1, c);
}
export function wbr(b_1, c) {
    return domEl("wbr", b_1, c);
}
export function svg(b_1, c) {
    return svgEl("svg", b_1, c);
}
export function circle(b_1, c) {
    return svgEl("circle", b_1, c);
}
export function clipPath(b_1, c) {
    return svgEl("clipPath", b_1, c);
}
export function defs(b_1, c) {
    return svgEl("defs", b_1, c);
}
export function ellipse(b_1, c) {
    return svgEl("ellipse", b_1, c);
}
export function g(b_1, c) {
    return svgEl("g", b_1, c);
}
export function image(b_1, c) {
    return svgEl("image", b_1, c);
}
export function line(b_1, c) {
    return svgEl("line", b_1, c);
}
export function linearGradient(b_1, c) {
    return svgEl("linearGradient", b_1, c);
}
export function mask(b_1, c) {
    return svgEl("mask", b_1, c);
}
export function path(b_1, c) {
    return svgEl("path", b_1, c);
}
export function pattern(b_1, c) {
    return svgEl("pattern", b_1, c);
}
export function polygon(b_1, c) {
    return svgEl("polygon", b_1, c);
}
export function polyline(b_1, c) {
    return svgEl("polyline", b_1, c);
}
export function radialGradient(b_1, c) {
    return svgEl("radialGradient", b_1, c);
}
export function rect(b_1, c) {
    return svgEl("rect", b_1, c);
}
export function stop(b_1, c) {
    return svgEl("stop", b_1, c);
}
export function text(b_1, c) {
    return svgEl("text", b_1, c);
}
export function tspan(b_1, c) {
    return svgEl("tspan", b_1, c);
}
//# sourceMappingURL=Fable.Helpers.React.js.map