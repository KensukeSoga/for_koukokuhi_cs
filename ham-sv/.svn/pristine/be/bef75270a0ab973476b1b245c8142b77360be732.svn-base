package jp.co.isid.ham.media.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 内容費目VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindExpenseItemListVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindExpenseItemListVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindExpenseItemListVO();
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMEDIACD() {
        return (String) get(Tbj02EigyoDaicho.MEDIACD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setMEDIACD(String val) {
        set(Tbj02EigyoDaicho.MEDIACD, val);
    }

    /**
     * 内容費目を取得する
     *
     * @return 内容費目
     */
    public String getNAIYOHIMOKU() {
        return (String) get(Tbj02EigyoDaicho.NAIYOHIMOKU);
    }

    /**
     * 内容費目を設定する
     *
     * @param val 内容費目
     */
    public void setNAIYOHIMOKU(String val) {
        set(Tbj02EigyoDaicho.NAIYOHIMOKU, val);
    }

}
