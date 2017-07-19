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
* ���W�I�ԑg�ꗗ�\����񌋉ʃZ�b�g
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2015/10/31 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdProgramRegisterResult extends AbstractServiceResult {

    /** �Z�L�����e�B��� */
    private List<SecurityInfoVO> _securityInfo = null;
    /** �@�\������ */
    private List<FunctionControlInfoVO> _functionInfo = null;
    /** �X�v���b�h�ꗗ��� */
    private List<Mbj37DisplayControlVO> _spdControl = null;
    /** �ꗗ�\���p�^�[����� */
    private List<Tbj30DisplayPatternVO> _dispPattern = null;
    /** �R�[�h�}�X�^��� */
    private List<Mbj12CodeVO> _code = null;
    /** ���W�I�ǃ}�X�^ */
    private List<Mbj50RdStationVO> _rdStation = null;
    /** ���W�I�ԑg��� */
    private List<Tbj37RdProgramVO> _rdProgram = null;
    /** ���W�I�ԑg�g��� */
    private List<Tbj38RdProgramMaterialVO> _rdProgramWaku = null;
    /** ���W�I�ԑg�l�b�g�Ǐ�� */
    private List<Tbj39RdProgramStationVO> _rdProgramStation = null;
    /** ���W�I�ԑg�f�ޏ�� */
    private List<FindRdProgramMaterialVO> _rdProgramMaterial = null;

    /**
     * �Z�L�����e�B�����擾����
     * @return List<SecurityInfoVO> �Z�L�����e�B���
     */
    public List<SecurityInfoVO> getSecurityInfo() {
        return _securityInfo;
    }

    /**
     * �Z�L�����e�B����ݒ肷��
     * @param vo List<SecurityInfoVO> �Z�L�����e�B���
     */
    public void setSecurityInfo(List<SecurityInfoVO> vo) {
        _securityInfo = vo;
    }

    /**
     * �@�\��������擾����
     * @return List<FunctionControlInfoVO> �@�\������
     */
    public List<FunctionControlInfoVO> getFunctionControlInfo() {
        return _functionInfo;
    }

    /**
     * �@�\�������ݒ肷��
     * @param vo List<FunctionControlInfoVO> �@�\������
     */
    public void setFunctionControlInfo(List<FunctionControlInfoVO> vo) {
        _functionInfo = vo;
    }

    /**
     * �X�v���b�h�ꗗ�����擾����
     * @return List<Mbj37DisplayControlVO> �X�v���b�h�ꗗ���
     */
    public List<Mbj37DisplayControlVO> getSpdControl() {
        return _spdControl;
    }

    /**
     * �X�v���b�h�ꗗ����ݒ肷��
     * @param vo List<Mbj37DisplayControlVO> �X�v���b�h�ꗗ���
     */
    public void setSpdControl(List<Mbj37DisplayControlVO> vo) {
        _spdControl = vo;
    }

    /**
     * �ꗗ�\���p�^�[�������擾����
     * @return List<Tbj30DisplayPatternVO> �ꗗ�\���p�^�[�����
     */
    public List<Tbj30DisplayPatternVO> getDispPattern() {
        return _dispPattern;
    }

    /**
     * �ꗗ�\���p�^�[������ݒ肷��
     * @param vo List<Tbj30DisplayPatternVO> �ꗗ�\���p�^�[�����
     */
    public void setDispPattern(List<Tbj30DisplayPatternVO> vo) {
        _dispPattern = vo;
    }

    /**
     * �R�[�h�}�X�^�����擾����
     * @return List<Mbj12CodeVO> �R�[�h�}�X�^���
     */
    public List<Mbj12CodeVO> getCode() {
        return _code;
    }

    /**
     * �R�[�h�}�X�^����ݒ肷��
     * @param vo List<Mbj12CodeVO> �R�[�h�}�X�^���
     */
    public void setCode(List<Mbj12CodeVO> vo) {
        _code = vo;
    }

    /**
     * ���W�I�ǃ}�X�^���擾����
     * @return List<Mbj50rdStationVO> ���W�I�ǃ}�X�^
     */
    public List<Mbj50RdStationVO> getRdStation() {
        return _rdStation;
    }

    /**
     * ���W�I�ǃ}�X�^��ݒ肷��
     * @param vo List<Mbj50rdStationVO> ���W�I�ǃ}�X�^
     */
    public void setRdStation(List<Mbj50RdStationVO> vo) {
        _rdStation = vo;
    }

    /**
     * ���W�I�ԑg�����擾����
     * @return List<Tbj37RdProgramVO> ���W�I�ԑg���
     */
    public List<Tbj37RdProgramVO> getRdProgram() {
        return _rdProgram;
    }

    /**
     * ���W�I�ԑg����ݒ肷��
     * @param vo List<Tbj37RdProgramVO> ���W�I�ԑg���
     */
    public void setRdProgram(List<Tbj37RdProgramVO> vo) {
        _rdProgram = vo;
    }

    /**
     * ���W�I�ԑg�g�Ǘ������擾����
     * @return List<Tbj38RdProgramMaterialVO> ���W�I�ԑg�g�Ǘ����
     */
    public List<Tbj38RdProgramMaterialVO> getRdProgramWaku() {
        return _rdProgramWaku;
    }

    /**
     * ���W�I�ԑg�g�Ǘ�����ݒ肷��
     * @param vo List<Tbj38RdProgramMaterialVO> ���W�I�ԑg�g�Ǘ����
     */
    public void setRdProgramWaku(List<Tbj38RdProgramMaterialVO> vo) {
        _rdProgramWaku = vo;
    }

    /**
     * ���W�I�ԑg�l�b�g�Ǐ����擾����
     * @return List<Tbj39RdProgramStationVO> ���W�I�ԑg�l�b�g�Ǐ��
     */
    public List<Tbj39RdProgramStationVO> getRdProgramStation() {
        return _rdProgramStation;
    }

    /**
     * ���W�I�ԑg�l�b�g�Ǐ���ݒ肷��
     * @param vo List<Tbj39RdProgramStationVO> ���W�I�ԑg�l�b�g�Ǐ��
     */
    public void setRdProgramStation(List<Tbj39RdProgramStationVO> vo) {
        _rdProgramStation = vo;
    }

    /**
     * ���W�I�ԑg�f�ޏ����擾����
     * @return List<FindRdProgramMaterialVO> ���W�I�ԑg�f�ޏ��
     */
    public List<FindRdProgramMaterialVO> getRdProgramMaterial() {
        return _rdProgramMaterial;
    }

    /**
     * ���W�I�ԑg�f�ޏ���ݒ肷��
     * @param vo List<FindRdProgramMaterialVO> ���W�I�ԑg�f�ޏ��
     */
    public void setRdProgramMaterial(List<FindRdProgramMaterialVO> vo) {
        _rdProgramMaterial = vo;
    }

}
