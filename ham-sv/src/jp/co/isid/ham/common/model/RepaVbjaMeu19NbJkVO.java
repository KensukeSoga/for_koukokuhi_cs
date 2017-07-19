package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu19NbJk;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 値引条件VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu19NbJkVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu19NbJkVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMeu19NbJkVO();
    }

    /**
     * 取引先企業コードを取得する
     *
     * @return 取引先企業コード
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu19NbJk.THSKGYCD);
    }

    /**
     * 取引先企業コードを設定する
     *
     * @param val 取引先企業コード
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu19NbJk.THSKGYCD, val);
    }

    /**
     * ＳＥＱＮＯを取得する
     *
     * @return ＳＥＱＮＯ
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu19NbJk.SEQNO);
    }

    /**
     * ＳＥＱＮＯを設定する
     *
     * @param val ＳＥＱＮＯ
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu19NbJk.SEQNO, val);
    }

    /**
     * 取担当ＳＥＱＮＯを取得する
     *
     * @return 取担当ＳＥＱＮＯ
     */
    public String getTRTNTSEQNO() {
        return (String) get(RepaVbjaMeu19NbJk.TRTNTSEQNO);
    }

    /**
     * 取担当ＳＥＱＮＯを設定する
     *
     * @param val 取担当ＳＥＱＮＯ
     */
    public void setTRTNTSEQNO(String val) {
        set(RepaVbjaMeu19NbJk.TRTNTSEQNO, val);
    }

    /**
     * 値引申請ＮＯを取得する
     *
     * @return 値引申請ＮＯ
     */
    public String getNBIKSINSEINO() {
        return (String) get(RepaVbjaMeu19NbJk.NBIKSINSEINO);
    }

    /**
     * 値引申請ＮＯを設定する
     *
     * @param val 値引申請ＮＯ
     */
    public void setNBIKSINSEINO(String val) {
        set(RepaVbjaMeu19NbJk.NBIKSINSEINO, val);
    }

    /**
     * 決済年月を取得する
     *
     * @return 決済年月
     */
    public String getKESYM() {
        return (String) get(RepaVbjaMeu19NbJk.KESYM);
    }

    /**
     * 決済年月を設定する
     *
     * @param val 決済年月
     */
    public void setKESYM(String val) {
        set(RepaVbjaMeu19NbJk.KESYM, val);
    }

    /**
     * 有効終了年月日を取得する
     *
     * @return 有効終了年月日
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu19NbJk.ENDYMD);
    }

    /**
     * 有効終了年月日を設定する
     *
     * @param val 有効終了年月日
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu19NbJk.ENDYMD, val);
    }

    /**
     * 有効開始年月日を取得する
     *
     * @return 有効開始年月日
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu19NbJk.STARTYMD);
    }

    /**
     * 有効開始年月日を設定する
     *
     * @param val 有効開始年月日
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu19NbJk.STARTYMD, val);
    }

    /**
     * 申請者コードを取得する
     *
     * @return 申請者コード
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu19NbJk.SNSTNT);
    }

    /**
     * 申請者コードを設定する
     *
     * @param val 申請者コード
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu19NbJk.SNSTNT, val);
    }

    /**
     * 適用開始年月日を取得する
     *
     * @return 適用開始年月日
     */
    public String getTYSYMD() {
        return (String) get(RepaVbjaMeu19NbJk.TYSYMD);
    }

    /**
     * 適用開始年月日を設定する
     *
     * @param val 適用開始年月日
     */
    public void setTYSYMD(String val) {
        set(RepaVbjaMeu19NbJk.TYSYMD, val);
    }

    /**
     * 適用終了年月日を取得する
     *
     * @return 適用終了年月日
     */
    public String getTYEYMD() {
        return (String) get(RepaVbjaMeu19NbJk.TYEYMD);
    }

    /**
     * 適用終了年月日を設定する
     *
     * @param val 適用終了年月日
     */
    public void setTYEYMD(String val) {
        set(RepaVbjaMeu19NbJk.TYEYMD, val);
    }

    /**
     * 決済日を取得する
     *
     * @return 決済日
     */
    public String getKESDAY() {
        return (String) get(RepaVbjaMeu19NbJk.KESDAY);
    }

    /**
     * 決済日を設定する
     *
     * @param val 決済日
     */
    public void setKESDAY(String val) {
        set(RepaVbjaMeu19NbJk.KESDAY, val);
    }

    /**
     * 申請局コードを取得する
     *
     * @return 申請局コード
     */
    public String getSNSKYK() {
        return (String) get(RepaVbjaMeu19NbJk.SNSKYK);
    }

    /**
     * 申請局コードを設定する
     *
     * @param val 申請局コード
     */
    public void setSNSKYK(String val) {
        set(RepaVbjaMeu19NbJk.SNSKYK, val);
    }

}
