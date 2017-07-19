package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * タレント・ナレーター・楽曲契約表検索(帳票用)の検索結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/03/26 T.Hadate)<BR>
 * </P>
 * @author Takahiro Hadate
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class Contract4ReportResult extends AbstractServiceResult {
    /* =============================================================================================*/
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得する.
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定する.
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/

    /** 帳票出力 出力リスト */
    private List<Contract4ReportVO> _contract4ReportVOList = null;

    /**
     * 帳票出力 出力リストを取得する.
     * @return 帳票出力 出力リスト
     */
    public List<Contract4ReportVO> getContract4ReportVOList() {
        return _contract4ReportVOList;
    }

    /**
     * 帳票出力 出力リストを設定する.
     * @param contract4ReportVOList 帳票出力 出力リスト
     */
    public void setContract4ReportVOList(List<Contract4ReportVO> contract4ReportVOList) {
        this._contract4ReportVOList = contract4ReportVOList;
    }


}
