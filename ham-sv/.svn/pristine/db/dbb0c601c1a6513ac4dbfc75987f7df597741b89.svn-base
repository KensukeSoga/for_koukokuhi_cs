package jp.co.isid.ham.production.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 素材登録　登録実行時の登録データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/12/17 HLC K.Soga)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class UsedRdProgramMaterialVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new UsedRdProgramMaterialVO();
    }

    /**
     * ラジオ番組SEQNOを設定します
     * @param val
     */
    public void setRDSEQNO(BigDecimal val) {
        set(Tbj38RdProgramMaterial.RDSEQNO, val);
    }

    /**
     * ラジオ番組SEQNOを取得します
     * @return
     */
    public BigDecimal getRDSEQNO() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.RDSEQNO);
    }

    /**
     * 年月を設定します
     * @param val
     */
    public void setYEARMONTH(String val) {
        set(Tbj38RdProgramMaterial.YEARMONTH, val);
    }

    /**
     * 年月を取得します
     * @return
     */
    public String getYEARMONTH() {
        return (String) get(Tbj38RdProgramMaterial.YEARMONTH);
    }

    /**
     * 枠SEQNOを設定します
     * @param val
     */
    public void setWAKUSEQNO(BigDecimal val) {
        set(Tbj38RdProgramMaterial.WAKUSEQ, val);
    }

    /**
     * 枠SEQNOを取得します
     * @return
     */
    public BigDecimal getWAKUSEQNO() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.WAKUSEQ);
    }

    /**
     * データ区分を設定します
     * @param val
     */
    public void setNO(BigDecimal val) {
        set(Mbj51Natural.NO, val);
    }

    /**
     * データ区分を取得します
     * @return
     */
    public BigDecimal getNO() {
        return (BigDecimal) get(Mbj51Natural.NO);
    }

    /**
     * 10桁CMコードを設定します
     * @param val
     */
    public void setCMCD(String val) {
        set(Tbj18SozaiKanriData.CMCD, val);
    }

    /**
     * 10桁CMコードを取得します
     * @return
     */
    public String getCMCD() {
        return (String) get(Tbj18SozaiKanriData.CMCD);
    }
}