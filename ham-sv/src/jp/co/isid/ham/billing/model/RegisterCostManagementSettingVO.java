package jp.co.isid.ham.billing.model;

import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj21SeisakuhiVO;
import jp.co.isid.ham.common.model.Tbj22SeisakuhiSsVO;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 制作費登録VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class RegisterCostManagementSettingVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 制作費VO */
    private List<Tbj21SeisakuhiVO> _seisakuhiVo;

    /** 制作費取込VO */
    private List<Tbj22SeisakuhiSsVO> _seisakuhiSsVo;

    /** フェイズ */
    private int _phase = 0;

    /** 年月 */
    private String _yearMonth = null;

    /** データ数 */
    private int _dataCount = 0;

    /** 最終更新日 */
    private Date _latestUpdDate = null;

    /** 最終更新者 */
    private String _lagestUpdId = null;


    /**
     * デフォルトコンストラクタ
     */
    public RegisterCostManagementSettingVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new RegisterCostManagementSettingVO();
    }

    /**
     * 制作費VOを取得する
     *
     * @return 制作費VO
     */
    public List<Tbj21SeisakuhiVO> getSeisakuhiVo() {
        return _seisakuhiVo;
    }

    /**
     * 制作費VOを設定する
     *
     * @param seisakuhiVo 制作費VO
     */
    public void setSeisakuhiVo(List<Tbj21SeisakuhiVO> seisakuhiVo) {
        _seisakuhiVo = seisakuhiVo;
    }

    /**
     * 制作費取込VOを取得する
     *
     * @return 制作費取込VO
     */
    public List<Tbj22SeisakuhiSsVO> getSeisakuhiSsVo() {
        return _seisakuhiSsVo;
    }

    /**
     * 制作費取込VOを設定する
     *
     * @param seisakuhiSsVo 制作費取込
     */
    public void setSeisakuhiSsVo(List<Tbj22SeisakuhiSsVO> seisakuhiSsVo) {
        _seisakuhiSsVo = seisakuhiSsVo;
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(int phase) {
        _phase = phase;
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * 年月を設定する
     *
     * @param yearMonth 年月
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /**
     * データ数を取得する
     * @return
     */
    public int getDataCount() {
        return _dataCount;
    }

    /**
     * データ数を設定する
     *
     * @param dataCount データ数
     */
    public void setDataCount(int dataCount) {
        _dataCount = dataCount;
    }

    /**
     * 最終更新日を取得する
     *
     * @return 最終更新日
     */
    @XmlElement(required = true, nillable = true)
    public Date getLatestUpdDate() {
        return _latestUpdDate;
    }

    /**
     * 最終更新日を設定する
     *
     * @param latestUpdDate 最終更新日
     */
    public void setLatestUpdDate(Date latestUpdDate) {
        _latestUpdDate = latestUpdDate;
    }

    /**
     * 最終更新者IDを取得する
     *
     * @return 最終更新者ID
     */
    public String getLatestUpdId() {
        return _lagestUpdId;
    }

    /**
     * 最終更新者IDを設定する
     *
     * @param lagestUpdId 最終更新者ID
     */
    public void setLatestUpdId(String lagestUpdId) {
        _lagestUpdId = lagestUpdId;
    }
}
