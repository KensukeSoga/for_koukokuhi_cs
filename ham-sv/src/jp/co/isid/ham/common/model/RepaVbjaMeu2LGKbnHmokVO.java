package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu2LGKbnHmok;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 業務区分費目対応マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu2LGKbnHmokVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu2LGKbnHmokVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMeu2LGKbnHmokVO();
    }

    /**
     * 業務区分を取得する
     *
     * @return 業務区分
     */
    public String getGYOMKBN() {
        return (String) get(RepaVbjaMeu2LGKbnHmok.GYOMKBN);
    }

    /**
     * 業務区分を設定する
     *
     * @param val 業務区分
     */
    public void setGYOMKBN(String val) {
        set(RepaVbjaMeu2LGKbnHmok.GYOMKBN, val);
    }

    /**
     * 費目コードを取得する
     *
     * @return 費目コード
     */
    public String getHMOKCD() {
        return (String) get(RepaVbjaMeu2LGKbnHmok.HMOKCD);
    }

    /**
     * 費目コードを設定する
     *
     * @param val 費目コード
     */
    public void setHMOKCD(String val) {
        set(RepaVbjaMeu2LGKbnHmok.HMOKCD, val);
    }

    /**
     * 発行年月日を取得する
     *
     * @return 発行年月日
     */
    public String getHKYMD() {
        return (String) get(RepaVbjaMeu2LGKbnHmok.HKYMD);
    }

    /**
     * 発行年月日を設定する
     *
     * @param val 発行年月日
     */
    public void setHKYMD(String val) {
        set(RepaVbjaMeu2LGKbnHmok.HKYMD, val);
    }

    /**
     * 費目表示順を取得する
     *
     * @return 費目表示順
     */
    public String getHMOKSEQ() {
        return (String) get(RepaVbjaMeu2LGKbnHmok.HMOKSEQ);
    }

    /**
     * 費目表示順を設定する
     *
     * @param val 費目表示順
     */
    public void setHMOKSEQ(String val) {
        set(RepaVbjaMeu2LGKbnHmok.HMOKSEQ, val);
    }

    /**
     * 廃止年月日を取得する
     *
     * @return 廃止年月日
     */
    public String getHAISYMD() {
        return (String) get(RepaVbjaMeu2LGKbnHmok.HAISYMD);
    }

    /**
     * 廃止年月日を設定する
     *
     * @param val 廃止年月日
     */
    public void setHAISYMD(String val) {
        set(RepaVbjaMeu2LGKbnHmok.HAISYMD, val);
    }

    /**
     * 海外区分を取得する
     *
     * @return 海外区分
     */
    public String getKAIGAIKBN() {
        return (String) get(RepaVbjaMeu2LGKbnHmok.KAIGAIKBN);
    }

    /**
     * 海外区分を設定する
     *
     * @param val 海外区分
     */
    public void setKAIGAIKBN(String val) {
        set(RepaVbjaMeu2LGKbnHmok.KAIGAIKBN, val);
    }

}
