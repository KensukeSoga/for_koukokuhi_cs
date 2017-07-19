package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.FunctionControlInfoVO;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.Mbj50RdStationVO;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.common.model.Tbj37RdProgramVO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialVO;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* ラジオ番組一覧表示情報結果セット
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdProgramRegisterResult extends AbstractServiceResult {

    /** セキュリティ情報 */
    private List<SecurityInfoVO> _securityInfo = null;
    /** 機能制御情報 */
    private List<FunctionControlInfoVO> _functionInfo = null;
    /** スプレッド一覧情報 */
    private List<Mbj37DisplayControlVO> _spdControl = null;
    /** 一覧表示パターン情報 */
    private List<Tbj30DisplayPatternVO> _dispPattern = null;
    /** コードマスタ情報 */
    private List<Mbj12CodeVO> _code = null;
    /** ラジオ局マスタ */
    private List<Mbj50RdStationVO> _rdStation = null;
    /** ラジオ番組情報 */
    private List<Tbj37RdProgramVO> _rdProgram = null;
    /** ラジオ番組枠情報 */
    private List<Tbj38RdProgramMaterialVO> _rdProgramWaku = null;
    /** ラジオ番組ネット局情報 */
    private List<Tbj39RdProgramStationVO> _rdProgramStation = null;
    /** ラジオ番組素材情報 */
    private List<FindRdProgramMaterialVO> _rdProgramMaterial = null;

    /**
     * セキュリティ情報を取得する
     * @return List<SecurityInfoVO> セキュリティ情報
     */
    public List<SecurityInfoVO> getSecurityInfo() {
        return _securityInfo;
    }

    /**
     * セキュリティ情報を設定する
     * @param vo List<SecurityInfoVO> セキュリティ情報
     */
    public void setSecurityInfo(List<SecurityInfoVO> vo) {
        _securityInfo = vo;
    }

    /**
     * 機能制御情報を取得する
     * @return List<FunctionControlInfoVO> 機能制御情報
     */
    public List<FunctionControlInfoVO> getFunctionControlInfo() {
        return _functionInfo;
    }

    /**
     * 機能制御情報を設定する
     * @param vo List<FunctionControlInfoVO> 機能制御情報
     */
    public void setFunctionControlInfo(List<FunctionControlInfoVO> vo) {
        _functionInfo = vo;
    }

    /**
     * スプレッド一覧情報を取得する
     * @return List<Mbj37DisplayControlVO> スプレッド一覧情報
     */
    public List<Mbj37DisplayControlVO> getSpdControl() {
        return _spdControl;
    }

    /**
     * スプレッド一覧情報を設定する
     * @param vo List<Mbj37DisplayControlVO> スプレッド一覧情報
     */
    public void setSpdControl(List<Mbj37DisplayControlVO> vo) {
        _spdControl = vo;
    }

    /**
     * 一覧表示パターン情報を取得する
     * @return List<Tbj30DisplayPatternVO> 一覧表示パターン情報
     */
    public List<Tbj30DisplayPatternVO> getDispPattern() {
        return _dispPattern;
    }

    /**
     * 一覧表示パターン情報を設定する
     * @param vo List<Tbj30DisplayPatternVO> 一覧表示パターン情報
     */
    public void setDispPattern(List<Tbj30DisplayPatternVO> vo) {
        _dispPattern = vo;
    }

    /**
     * コードマスタ情報を取得する
     * @return List<Mbj12CodeVO> コードマスタ情報
     */
    public List<Mbj12CodeVO> getCode() {
        return _code;
    }

    /**
     * コードマスタ情報を設定する
     * @param vo List<Mbj12CodeVO> コードマスタ情報
     */
    public void setCode(List<Mbj12CodeVO> vo) {
        _code = vo;
    }

    /**
     * ラジオ局マスタを取得する
     * @return List<Mbj50rdStationVO> ラジオ局マスタ
     */
    public List<Mbj50RdStationVO> getRdStation() {
        return _rdStation;
    }

    /**
     * ラジオ局マスタを設定する
     * @param vo List<Mbj50rdStationVO> ラジオ局マスタ
     */
    public void setRdStation(List<Mbj50RdStationVO> vo) {
        _rdStation = vo;
    }

    /**
     * ラジオ番組情報を取得する
     * @return List<Tbj37RdProgramVO> ラジオ番組情報
     */
    public List<Tbj37RdProgramVO> getRdProgram() {
        return _rdProgram;
    }

    /**
     * ラジオ番組情報を設定する
     * @param vo List<Tbj37RdProgramVO> ラジオ番組情報
     */
    public void setRdProgram(List<Tbj37RdProgramVO> vo) {
        _rdProgram = vo;
    }

    /**
     * ラジオ番組枠管理情報を取得する
     * @return List<Tbj38RdProgramMaterialVO> ラジオ番組枠管理情報
     */
    public List<Tbj38RdProgramMaterialVO> getRdProgramWaku() {
        return _rdProgramWaku;
    }

    /**
     * ラジオ番組枠管理情報を設定する
     * @param vo List<Tbj38RdProgramMaterialVO> ラジオ番組枠管理情報
     */
    public void setRdProgramWaku(List<Tbj38RdProgramMaterialVO> vo) {
        _rdProgramWaku = vo;
    }

    /**
     * ラジオ番組ネット局情報を取得する
     * @return List<Tbj39RdProgramStationVO> ラジオ番組ネット局情報
     */
    public List<Tbj39RdProgramStationVO> getRdProgramStation() {
        return _rdProgramStation;
    }

    /**
     * ラジオ番組ネット局情報を設定する
     * @param vo List<Tbj39RdProgramStationVO> ラジオ番組ネット局情報
     */
    public void setRdProgramStation(List<Tbj39RdProgramStationVO> vo) {
        _rdProgramStation = vo;
    }

    /**
     * ラジオ番組素材情報を取得する
     * @return List<FindRdProgramMaterialVO> ラジオ番組素材情報
     */
    public List<FindRdProgramMaterialVO> getRdProgramMaterial() {
        return _rdProgramMaterial;
    }

    /**
     * ラジオ番組素材情報を設定する
     * @param vo List<FindRdProgramMaterialVO> ラジオ番組素材情報
     */
    public void setRdProgramMaterial(List<FindRdProgramMaterialVO> vo) {
        _rdProgramMaterial = vo;
    }

}
