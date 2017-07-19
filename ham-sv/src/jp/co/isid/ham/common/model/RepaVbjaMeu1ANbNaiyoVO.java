package jp.co.isid.ham.common.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu1ANbNaiyo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 値引内容VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu1ANbNaiyoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMeu1ANbNaiyoVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RepaVbjaMeu1ANbNaiyoVO();
    }

    /**
     * 取引先企業コードを取得する
     *
     * @return 取引先企業コード
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.THSKGYCD);
    }

    /**
     * 取引先企業コードを設定する
     *
     * @param val 取引先企業コード
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.THSKGYCD, val);
    }

    /**
     * ＳＥＱＮＯを取得する
     *
     * @return ＳＥＱＮＯ
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.SEQNO);
    }

    /**
     * ＳＥＱＮＯを設定する
     *
     * @param val ＳＥＱＮＯ
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu1ANbNaiyo.SEQNO, val);
    }

    /**
     * 取担当ＳＥＱＮＯを取得する
     *
     * @return 取担当ＳＥＱＮＯ
     */
    public String getTRTNTSEQNO() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.TRTNTSEQNO);
    }

    /**
     * 取担当ＳＥＱＮＯを設定する
     *
     * @param val 取担当ＳＥＱＮＯ
     */
    public void setTRTNTSEQNO(String val) {
        set(RepaVbjaMeu1ANbNaiyo.TRTNTSEQNO, val);
    }

    /**
     * 値引申請ＮＯを取得する
     *
     * @return 値引申請ＮＯ
     */
    public String getNBIKSINSEINO() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKSINSEINO);
    }

    /**
     * 値引申請ＮＯを設定する
     *
     * @param val 値引申請ＮＯ
     */
    public void setNBIKSINSEINO(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKSINSEINO, val);
    }

    /**
     * 決済年月を取得する
     *
     * @return 決済年月
     */
    public String getKESYM() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.KESYM);
    }

    /**
     * 決済年月を設定する
     *
     * @param val 決済年月
     */
    public void setKESYM(String val) {
        set(RepaVbjaMeu1ANbNaiyo.KESYM, val);
    }

    /**
     * 申請ＳＥＱＮＯを取得する
     *
     * @return 申請ＳＥＱＮＯ
     */
    public String getSNSSEQNO() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.SNSSEQNO);
    }

    /**
     * 申請ＳＥＱＮＯを設定する
     *
     * @param val 申請ＳＥＱＮＯ
     */
    public void setSNSSEQNO(String val) {
        set(RepaVbjaMeu1ANbNaiyo.SNSSEQNO, val);
    }

    /**
     * 有効終了年月日を取得する
     *
     * @return 有効終了年月日
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.ENDYMD);
    }

    /**
     * 有効終了年月日を設定する
     *
     * @param val 有効終了年月日
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.ENDYMD, val);
    }

    /**
     * 有効開始年月日を取得する
     *
     * @return 有効開始年月日
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.STARTYMD);
    }

    /**
     * 有効開始年月日を設定する
     *
     * @param val 有効開始年月日
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.STARTYMD, val);
    }

    /**
     * 決済日を取得する
     *
     * @return 決済日
     */
    public String getKESDAY() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.KESDAY);
    }

    /**
     * 決済日を設定する
     *
     * @param val 決済日
     */
    public void setKESDAY(String val) {
        set(RepaVbjaMeu1ANbNaiyo.KESDAY, val);
    }

    /**
     * 適用開始年月日を取得する
     *
     * @return 適用開始年月日
     */
    public String getTYSYMD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.TYSYMD);
    }

    /**
     * 適用開始年月日を設定する
     *
     * @param val 適用開始年月日
     */
    public void setTYSYMD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.TYSYMD, val);
    }

    /**
     * 適用終了年月日を取得する
     *
     * @return 適用終了年月日
     */
    public String getTYEYMD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.TYEYMD);
    }

    /**
     * 適用終了年月日を設定する
     *
     * @param val 適用終了年月日
     */
    public void setTYEYMD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.TYEYMD, val);
    }

    /**
     * 申請者コードを取得する
     *
     * @return 申請者コード
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.SNSTNT);
    }

    /**
     * 申請者コードを設定する
     *
     * @param val 申請者コード
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu1ANbNaiyo.SNSTNT, val);
    }

    /**
     * 業務区分を取得する
     *
     * @return 業務区分
     */
    public String getGYOMKBN() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.GYOMKBN);
    }

    /**
     * 業務区分を設定する
     *
     * @param val 業務区分
     */
    public void setGYOMKBN(String val) {
        set(RepaVbjaMeu1ANbNaiyo.GYOMKBN, val);
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getBTAICD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.BTAICD);
    }

    /**
     * 媒体コードを設定する
     *
     * @param val 媒体コード
     */
    public void setBTAICD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.BTAICD, val);
    }

    /**
     * 費目コードを取得する
     *
     * @return 費目コード
     */
    public String getHMOKCD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.HMOKCD);
    }

    /**
     * 費目コードを設定する
     *
     * @param val 費目コード
     */
    public void setHMOKCD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.HMOKCD, val);
    }

    /**
     * 駅路線を取得する
     *
     * @return 駅路線
     */
    public String getROSENCD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.ROSENCD);
    }

    /**
     * 駅路線を設定する
     *
     * @param val 駅路線
     */
    public void setROSENCD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.ROSENCD, val);
    }

    /**
     * 新聞中央・地方区分を取得する
     *
     * @return 新聞中央・地方区分
     */
    public String getMSCHUOCHIHKBN() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.MSCHUOCHIHKBN);
    }

    /**
     * 新聞中央・地方区分を設定する
     *
     * @param val 新聞中央・地方区分
     */
    public void setMSCHUOCHIHKBN(String val) {
        set(RepaVbjaMeu1ANbNaiyo.MSCHUOCHIHKBN, val);
    }

    /**
     * 国際区分を取得する
     *
     * @return 国際区分
     */
    public String getKKSIKBN() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.KKSIKBN);
    }

    /**
     * 国際区分を設定する
     *
     * @param val 国際区分
     */
    public void setKKSIKBN(String val) {
        set(RepaVbjaMeu1ANbNaiyo.KKSIKBN, val);
    }

    /**
     * ＥＬ・製版・企画区分を取得する
     *
     * @return ＥＬ・製版・企画区分
     */
    public String getELSHANKKAKKBN() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.ELSHANKKAKKBN);
    }

    /**
     * ＥＬ・製版・企画区分を設定する
     *
     * @param val ＥＬ・製版・企画区分
     */
    public void setELSHANKKAKKBN(String val) {
        set(RepaVbjaMeu1ANbNaiyo.ELSHANKKAKKBN, val);
    }

    /**
     * 値引内容区分１を取得する
     *
     * @return 値引内容区分１
     */
    public String getNBIKNIYOKBN1() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN1);
    }

    /**
     * 値引内容区分１を設定する
     *
     * @param val 値引内容区分１
     */
    public void setNBIKNIYOKBN1(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN1, val);
    }

    /**
     * 値引内容区分２を取得する
     *
     * @return 値引内容区分２
     */
    public String getNBIKNIYOKBN2() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN2);
    }

    /**
     * 値引内容区分２を設定する
     *
     * @param val 値引内容区分２
     */
    public void setNBIKNIYOKBN2(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN2, val);
    }

    /**
     * 値引内容区分３を取得する
     *
     * @return 値引内容区分３
     */
    public String getNBIKNIYOKBN3() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN3);
    }

    /**
     * 値引内容区分３を設定する
     *
     * @param val 値引内容区分３
     */
    public void setNBIKNIYOKBN3(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN3, val);
    }

    /**
     * 値引内容区分４を取得する
     *
     * @return 値引内容区分４
     */
    public String getNBIKNIYOKBN4() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN4);
    }

    /**
     * 値引内容区分４を設定する
     *
     * @param val 値引内容区分４
     */
    public void setNBIKNIYOKBN4(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN4, val);
    }

    /**
     * 値引内容区分５を取得する
     *
     * @return 値引内容区分５
     */
    public String getNBIKNIYOKBN5() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN5);
    }

    /**
     * 値引内容区分５を設定する
     *
     * @param val 値引内容区分５
     */
    public void setNBIKNIYOKBN5(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN5, val);
    }

    /**
     * 値引率を取得する
     *
     * @return 値引率
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNBIKRITU() {
        return (BigDecimal) get(RepaVbjaMeu1ANbNaiyo.NBIKRITU);
    }

    /**
     * 値引率を設定する
     *
     * @param val 値引率
     */
    public void setNBIKRITU(BigDecimal val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKRITU, val);
    }

}
