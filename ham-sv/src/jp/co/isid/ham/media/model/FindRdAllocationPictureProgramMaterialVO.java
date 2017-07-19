package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ラジオ版AllocationPicture番組素材情報検索VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdAllocationPictureProgramMaterialVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindRdAllocationPictureProgramMaterialVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindRdAllocationPictureProgramMaterialVO();
    }

    /**
     * ラジオ番組SEQNOを取得する
     * @return BigDecimal ラジオ番組SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRDSEQNO() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.RDSEQNO);
    }

    /**
     * ラジオ番組SEQNOを設定する
     * @param val BigDecimal ラジオ番組SEQNO
     */
    public void setRDSEQNO(BigDecimal val) {
        set(Tbj38RdProgramMaterial.RDSEQNO, val);
    }

    /**
     * 年月を取得する
     * @return String 年月
     */
    public String getYEARMONTH() {
        return (String) get(Tbj38RdProgramMaterial.YEARMONTH);
    }

    /**
     * 年月を設定する
     * @param val String 年月
     */
    public void setYEARMONTH(String val) {
        set(Tbj38RdProgramMaterial.YEARMONTH, val);
    }

    /**
     * 枠SEQNOを取得する
     * @return BigDecimal 枠SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getWAKUSEQ() {
        return (BigDecimal) get(Tbj38RdProgramMaterial.WAKUSEQ);
    }

    /**
     * 枠SEQNOを設定する
     * @param val BigDecimal 枠SEQNO
     */
    public void setWAKUSEQ(BigDecimal val) {
        set(Tbj38RdProgramMaterial.WAKUSEQ, val);
    }

    /**
     * 日付を取得する
     * @return BigDecimal 日付
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNO() {
        return (BigDecimal) get(Mbj51Natural.NO);
    }

    /**
     * 日付を設定する
     * @param val BigDecimal 日付
     */
    public void setNO(BigDecimal val) {
        set(Mbj51Natural.NO, val);
    }

    /**
     * 10桁CMコードを取得する
     * @return String 10桁CMコード
     */
    public String getCMCD() {
        return (String) get(Tbj18SozaiKanriData.CMCD);
    }

    /**
     * 10桁CMコードを設定する
     * @param val String 10桁CMコード
     */
    public void setCMCD(String val) {
        set(Tbj18SozaiKanriData.CMCD, val);
    }

}
