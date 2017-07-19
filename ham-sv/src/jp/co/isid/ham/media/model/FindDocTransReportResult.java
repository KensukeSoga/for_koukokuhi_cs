package jp.co.isid.ham.media.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Mbj32DepartmentVO;
import jp.co.isid.ham.common.model.Mbj47NewspaperVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
* <P>
* 送稿表の帳票情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/09/26 Fujiyoshi)<BR>
* </P>
* @author Fujiyoshi
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindDocTransReportResult extends AbstractServiceResult {

    /** 帳票出力データ */
    private List<FindDocTransReportVO> _reportVo;

    /** 部署マスタ */
    private List<Mbj32DepartmentVO> _depVo;

    /** 新聞マスタ */
    private  List<Mbj47NewspaperVO> _npVo;


    /**
     * 帳票出力データ
     *
     * @return 帳票出力データ
     */
    public List<FindDocTransReportVO> getReport() {
        return _reportVo;
    }

    /**
     * 帳票出力データ
     *
     * @param reportVo 帳票出力データ
     */
    public void setReport(List<FindDocTransReportVO> reportVo) {
        _reportVo = reportVo;
    }

    /**
     * 部署マスタ
     *
     * @return 部署マスタ
     */
    public List<Mbj32DepartmentVO> getDep() {
        return _depVo;
    }

    /**
     * 部署マスタ
     *
     * @param depVo 部署マスタ
     */
    public void setDep(List<Mbj32DepartmentVO>  depVo) {
        _depVo = depVo;
    }

    /**
     * 新聞マスタ
     *
     * @return 新聞マスタ
     */
    public List<Mbj47NewspaperVO> getNp() {
        return _npVo;
    }

    /**
     * 新聞マスタ
     *
     * @param npVo 新聞マスタ
     */
    public void setNp(List<Mbj47NewspaperVO> npVo) {
        _npVo = npVo;
    }


    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}
