package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj17ContentVO;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj40TempSozaiContentVO;


/**
 * <P>
 * 契約情報登録　登録実行時の登録データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * ・JASRAC対応(2015/12/01 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class UpdateContractInfoVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** 検索条件VO */
    private UpdateContractInfoCondition _updateContractInfoCondition = null;

    /** 契約種類（排他チェック用） */
    private String _exclusionCtrtkbnForContractInfo;

    /** 契約コード（排他チェック用） */
    private String _exclusionCtrtnoForContractInfo;

    /** 契約情報登録のタイムスタンプ最大値 */
    private Date _maxDateTimeForContractInfo = null;

    /** 契約情報VO（削除）リスト */
    private List<Tbj16ContractInfoUpdateVO> _tbj16ContractInfoUpdateVOListDel = null;

    /** 契約情報VO（登録）リスト */
    private List<Tbj16ContractInfoUpdateVO> _tbj16ContractInfoUpdateVoListReg = null;

    /** 契約情報VO（更新）リスト */
    private List<Tbj16ContractInfoUpdateVO> _tbj16ContractInfoUpdateVoListUpd = null;

    /** 素材登録情報VO（削除）リスト */
    private List<Tbj18SozaiKanriDataVO> _tbj18SozaiKanriDataVOListDel = null;

    /** 素材登録情報VO（登録）リスト */
    private List<Tbj18SozaiKanriDataVO> _tbj18SozaiKanriDataVoListReg = null;

    /** 素材登録情報VO（更新）リスト */
    private List<Tbj18SozaiKanriDataVO> _tbj18SozaiKanriDataVoListUpd = null;

    /** コンテンツVO */
    private List<Tbj17ContentVO> _tbj17ContentVo = null;

    /* 2015/12/01 JASRAC対応 HLC S.Fujimoto ADD Start */
    /** 仮素材情報登録VO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36InsVoList = null;
    /** 仮素材情報更新VO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36UpdVoList = null;
    /** 仮素材情報削除VO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36DelVoList = null;
    /** 契約仮素材紐付け登録VO */
    private List<Tbj40TempSozaiContentVO> _tbj40VoList = null;
    /* 2015/12/01 JASRAC対応 HLC S.Fujimoto ADD End */

    /**
     * 検索条件を取得する
     *
     * @return 検索条件VO
     */
    public UpdateContractInfoCondition getUpdateContractInfoCondition() {
        return _updateContractInfoCondition;
    }

    /**
     * 検索条件を設定する
     *
     * @param updateContractInfoCondition 検索条件VO
     */
    public void setUpdateContractInfoCondition(UpdateContractInfoCondition updateContractInfoCondition) {
        this._updateContractInfoCondition = updateContractInfoCondition;
    }

    /**
     * 契約種類（排他チェック用）を取得する
     *
     * @return 契約種類（排他チェック用）
     */
    public String getExclusionCtrtkbnForContractInfo() {
        return _exclusionCtrtkbnForContractInfo;
    }

    /**
     * 契約種類（排他チェック用）を設定する
     *
     * @param exclusionCtrtkbnForContractInfo 契約種類（排他チェック用）
     */
    public void setExclusionCtrtkbnForContractInfo(String exclusionCtrtkbnForContractInfo) {
        this._exclusionCtrtkbnForContractInfo = exclusionCtrtkbnForContractInfo;
    }

    /**
     * 契約コード（排他チェック用）を取得する
     *
     * @return 契約コード（排他チェック用）
     */
    public String getExclusionCtrtnoForContractInfo() {
        return _exclusionCtrtnoForContractInfo;
    }

    /**
     * 契約コード（排他チェック用）を設定する
     *
     * @param exclusionCtrtnoForContractInfo 契約コード（排他チェック用）
     */
    public void setExclusionCtrtnoForContractInfo(String exclusionCtrtnoForContractInfo) {
        this._exclusionCtrtnoForContractInfo = exclusionCtrtnoForContractInfo;
    }

    /**
     * 契約情報登録のタイムスタンプ最大値を取得する
     *
     * @return 契約情報登録のタイムスタンプ最大値
     */
    @XmlElement(required = true, nillable=true)
    public Date getMaxDateTimeForContractInfo() {
        return _maxDateTimeForContractInfo;
    }

    /**
     * 契約情報登録のタイムスタンプ最大値を設定する
     *
     * @param maxDateTimeForContractInfo 契約情報登録のタイムスタンプ最大値
     */
    public void setMaxDateTimeForContractInfo(Date maxDateTimeForContractInfo) {
        this._maxDateTimeForContractInfo = maxDateTimeForContractInfo;
    }

    /**
     * 契約情報VO（削除）リストを取得する
     *
     * @return 契約情報VO（削除）リスト
     */
    public List<Tbj16ContractInfoUpdateVO> getTbj16ContractInfoUpdateVOListDel() {
        return _tbj16ContractInfoUpdateVOListDel;
    }

    /**
     * 契約情報VO（削除）リストを設定する
     *
     * @param tbj16ContractInfoUpdateVoListDel 契約情報VO（削除）リスト
     */
    public void setTbj16ContractInfoUpdateVOListDel(List<Tbj16ContractInfoUpdateVO> tbj16ContractInfoUpdateVoListDel) {
        this._tbj16ContractInfoUpdateVOListDel = tbj16ContractInfoUpdateVoListDel;
    }

    /**
     * 契約情報VO（登録）リストを取得する
     *
     * @return 契約情報VO（登録）リスト
     */
    public List<Tbj16ContractInfoUpdateVO> getTbj16ContractInfoUpdateVOListReg() {
        return _tbj16ContractInfoUpdateVoListReg;
    }

    /**
     * 契約情報VO（登録）を設定する
     *
     * @param tbj16ContractInfoUpdateVoListReg 契約情報VO（登録）リスト
     */
    public void setTbj16ContractInfoUpdateVOListReg(List<Tbj16ContractInfoUpdateVO> tbj16ContractInfoUpdateVoListReg) {
        this._tbj16ContractInfoUpdateVoListReg = tbj16ContractInfoUpdateVoListReg;
    }

    /**
     * 契約情報VO（更新）リストを取得する
     *
     * @return 契約情報VO（更新）リスト
     */
    public List<Tbj16ContractInfoUpdateVO> getTbj16ContractInfoUpdateVOListUpd() {
        return _tbj16ContractInfoUpdateVoListUpd;
    }

    /**
     * 契約情報VO（更新）リストを設定する
     *
     * @param tbj16ContractInfoUpdateVoListUpd 契約情報VO（更新）リスト
     */
    public void setTbj16ContractInfoUpdateVOListUpd(List<Tbj16ContractInfoUpdateVO> tbj16ContractInfoUpdateVoListUpd) {
        this._tbj16ContractInfoUpdateVoListUpd = tbj16ContractInfoUpdateVoListUpd;
    }

//    /**
//     * 素材登録情報VO（更新）リストを取得する
//     *
//     * @return 素材登録情報VO（更新）リスト
//     */
//    public List<Tbj18SozaiKanriDataUpdateVO> getTbj18SozaiKanriDataUpdateVO() {
//        return _tbj18SozaiKanriDataUpdateVO;
//    }
//
//    /**
//     * 素材登録情報VO（更新）リストを設定する
//     *
//     * @param tbj18SozaiKanriDataUpdateVO 素材登録情報VO（更新）リスト
//     */
//    public void setTbj18SozaiKanriDataUpdateVO(List<Tbj18SozaiKanriDataUpdateVO> tbj18SozaiKanriDataUpdateVO) {
//        this._tbj18SozaiKanriDataUpdateVO = tbj18SozaiKanriDataUpdateVO;
//    }

    /**
     * 素材登録情報VO（削除）リストを取得する
     *
     * @return 素材登録情報VO（削除）リスト
     */
    public List<Tbj18SozaiKanriDataVO> getTbj18SozaiKanriDataVOListDel() {
        return _tbj18SozaiKanriDataVOListDel;
    }

    /**
     * 素材登録情報VO（削除）リストを設定する
     *
     * @param tbj18SozaiKanriDataVoListDel 素材登録情報VO（削除）リスト
     */
    public void setTbj18SozaiKanriDataVOListDel(List<Tbj18SozaiKanriDataVO> tbj18SozaiKanriDataVoListDel) {
        this._tbj18SozaiKanriDataVOListDel = tbj18SozaiKanriDataVoListDel;
    }

    /**
     * 素材登録情報VO（登録）リストを取得する
     *
     * @return 素材登録情報VO（登録）リスト
     */
    public List<Tbj18SozaiKanriDataVO> getTbj18SozaiKanriDataVOListReg() {
        return _tbj18SozaiKanriDataVoListReg;
    }

    /**
     * 素材登録情報VO（登録）を設定する
     *
     * @param tbj18SozaiKanriDataVoListReg 素材登録情報VO（登録）リスト
     */
    public void setTbj18SozaiKanriDataVOListReg(List<Tbj18SozaiKanriDataVO> tbj18SozaiKanriDataVoListReg) {
        this._tbj18SozaiKanriDataVoListReg = tbj18SozaiKanriDataVoListReg;
    }

    /**
     * 素材登録情報VO（更新）リストを取得する
     *
     * @return 素材登録情報VO（更新）リスト
     */
    public List<Tbj18SozaiKanriDataVO> getTbj18SozaiKanriDataVOListUpd() {
        return _tbj18SozaiKanriDataVoListUpd;
    }

    /**
     * 素材登録情報VO（更新）リストを設定する
     *
     * @param tbj18SozaiKanriDataVoListUpd 素材登録情報VO（更新）リスト
     */
    public void setTbj18SozaiKanriDataVOListUpd(List<Tbj18SozaiKanriDataVO> tbj18SozaiKanriDataVoListUpd) {
        this._tbj18SozaiKanriDataVoListUpd = tbj18SozaiKanriDataVoListUpd;
    }

    /**
     * コンテンツVOリストを取得する
     *
     * @return コンテンツVOリスト
     */
    public List<Tbj17ContentVO> getTbj17ContentVo() {
        return _tbj17ContentVo;
    }

    /**
     * コンテンツVOリストを設定する
     *
     * @param tbj17ContentVo コンテンツVO
     */
    public void setTbj17ContentVo(List<Tbj17ContentVO> tbj17ContentVo) {
        this._tbj17ContentVo = tbj17ContentVo;
    }

    /* 2015/12/01 JASRAC対応 HLC S.Fujimoto ADD Start */
    /**
     * 仮素材情報登録VOを取得する
     * @return List<Tbj36TempSozaiKanriDataVO> 仮素材情報登録VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36InsVoList() {
        return _tbj36InsVoList;
    }

    /**
     * 仮素材情報登録VOを設定する
     * @param val List<Tbj36TempSozaiKanriDataVO> 仮素材情報登録VO
     */
    public void setTbj36InsVoList(List<Tbj36TempSozaiKanriDataVO> val) {
        _tbj36InsVoList = val;
    }

    /**
     * 仮素材情報更新VOを取得する
     * @return List<Tbj36TempSozaiKanriDataVO> 仮素材情報登録VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36UpdVoList() {
        return _tbj36UpdVoList;
    }

    /**
     * 仮素材情報更新VOを設定する
     * @param val List<Tbj36TempSozaiKanriDataVO> 仮素材情報更新VO
     */
    public void setTbj36UpdVoList(List<Tbj36TempSozaiKanriDataVO> val) {
        _tbj36UpdVoList = val;
    }

    /**
     * 仮素材情報削除VOを取得する
     * @return List<Tbj36TempSozaiKanriDataVO> 仮素材情報削除VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36DelVoList() {
        return _tbj36DelVoList;
    }

    /**
     * 仮素材情報削除VOを設定する
     * @param val List<Tbj36TempSozaiKanriDataVO> 仮素材情報削除VO
     */
    public void setTbj36DelVoList(List<Tbj36TempSozaiKanriDataVO> val) {
        _tbj36DelVoList = val;
    }

    /**
     * 契約仮素材紐付け登録VOを取得する
     * @return List<Tbj40TempSozaiContentVO> 契約仮素材紐付け登録VO
     */
    public List<Tbj40TempSozaiContentVO> getTbj40VoList() {
        return _tbj40VoList;
    }

    /**
     * 契約仮素材紐付け登録VOを設定する
     * @param val List<Tbj40TempSozaiContentVO> 契約仮素材紐付け登録VO
     */
    public void setTbj40VoList(List<Tbj40TempSozaiContentVO> val) {
        _tbj40VoList = val;
    }
    /* 2015/12/01 JASRAC対応 HLC S.Fujimoto ADD End */

}
